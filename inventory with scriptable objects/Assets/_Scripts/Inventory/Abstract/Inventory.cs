using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class Inventory
{
    private List<Item> itemList = new List<Item>();
    private List<Item> permaItemList = new List<Item>();
    public event EventHandler OnItemListChanged;


    public List<Item> GetItemList()
    {
        return itemList;
    }
    public bool InventoryFull()
    {
        if (itemList.Count >= 20) return true;
        else return false;
    }
    public void SortItemsByType()
    {
        List<Item> newItemList = new List<Item>();
        foreach(Item item in itemList)
        {
            newItemList.Add(item);
        }
        newItemList = newItemList.OrderBy(item => item.data.id).ToList();
        itemList.Clear();

        int position = 0;
        foreach(Item item in newItemList)
        {
            if (item.data.itemType == GlobalClass.ItemType.NonUsable)
            {
                itemList.Add(item);
                item.position = position;
                position++;
            }
        }
        foreach (Item item in newItemList)
        {
            if (item.data.itemType == GlobalClass.ItemType.Usable)
            {
                itemList.Add(item); 
                item.position = position;
                position++;
            }
        }
        foreach (Item item in newItemList)
        {
            if (item.data.itemType != GlobalClass.ItemType.NonUsable && item.data.itemType != GlobalClass.ItemType.Usable)
            {
                itemList.Add(item);
                item.position = position;
                position++;
            }
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public void AddItemById(int id) => AddItemById(id, 1);
    public void AddItemById(int id, int ammount) => AddItemById(id, ammount, null);
    public void AddItemById(int id, int ammount, ItemWorld itemWorld)
    {
        //0.permanent upgrade item does not go in inventory
        if (ItemDatabase.Instance.FetchItemById(id).goesInInventory == false)
        {
            if (itemWorld != null) itemWorld.UpdateItem(0);
            Debug.Log("Permanent player update");
            return;
        }
        //1.fill existing stacks
        foreach (Item item in itemList)
        {
            if (item.data == ItemDatabase.Instance.FetchItemById(id))
            {
                while (ammount > 0 && item.ammount < item.data.stackLimit)
                {
                    item.ammount++;
                    ammount--;
                }
            }
        }

        if (itemWorld != null) itemWorld.UpdateItem(ammount);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        if (itemList.Count >= 20)
        {
            Debug.Log($"Can't add more than {itemList.Count} item stacks.");
            return;
        }

        //2.add new stack
        if (ammount != 0)
        {
            Item newItem = new Item();
            for (int i = 0; i < 20; i++) //set index to 1st index that doesn't exsist
            {
                bool found = false;
                foreach (Item item in itemList)
                {
                    if (item.position == i) found = true;
                }
                if (!found)
                {
                    newItem.position = i;
                    break;
                }
            }

            if (ItemDatabase.Instance.FetchItemById(id) == null) Debug.Log("Item not found in database.");
            else newItem.data = ItemDatabase.Instance.FetchItemById(id);

            newItem.ammount = ammount;

            itemList.Add(newItem);
        }

        if (itemWorld != null) itemWorld.UpdateItem(0);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public Item AddItemAt(Item item, int index)
    {
        itemList.Add(item);
        item.position = index;

        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        return item;
    }
    public Item RemoveItem(Item item)
    {
        itemList.Remove(item);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        return item;
    }
    public void ConsumeItem(Item item)
    {
        item.ammount--;
        if (item.ammount <= 0) itemList.Remove(item);
        Debug.Log($"Item {item.data.name} consumed!");

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public void ClearInventory()
    {
        itemList.Clear();

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public void RefreshInventory()
    {
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public int GetLength()
    {
        return itemList.Count;
    }
    
}
public class Item
{
    public int position;
    public ItemData data;
    public int ammount;
}
