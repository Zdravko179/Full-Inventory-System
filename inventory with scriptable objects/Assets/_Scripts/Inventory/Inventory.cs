using System.Collections.Generic;
using System;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList = new List<Item>();
    public event EventHandler OnItemListChanged;


    public List<Item> GetItemList()
    {
        return itemList;
    }
    public void AddItemById(int id) => AddItemById(id, 1);
    public void AddItemById(int id, int ammount)
    {
        if (itemList.Count >= 20) Debug.Log("Invetory Full, Can't Add More Items");
        if (ammount > ItemDatabase.Instance.FetchItemById(id).stackLimit)
        {
            Debug.Log("Adding more than stack limit");
            ammount = ItemDatabase.Instance.FetchItemById(id).stackLimit;
        }

        foreach (Item item in itemList) //fill existing stacks
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

        if (ammount != 0) //add new stack
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
            if (ItemDatabase.Instance.FetchItemById(id) == null) Debug.Log("Item not found in database");
            else newItem.data = ItemDatabase.Instance.FetchItemById(id);
            newItem.ammount = ammount;
            itemList.Add(newItem);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public Item AddItemAt(Item item, int index)
    {
        itemList.Add(item);
        item.position = index;

        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        return item;
    }
    void AddItem(Item item, int position)
    {
        itemList.Add(item);
        item.position = position;
    }
    public void RemoveItem(Item item)
    {
        itemList.Remove(item);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    /*
    public void MoveItem(Item oldItem, int newIndex)
    {
        MoveItem(oldItem, null, 0, newIndex);
    }
    public void MoveItem(Item oldItem, Item_Y newItem, int oldIndex, int newIndex)
    {
        oldItem.index = newIndex;
        if (newItem != null) newItem.index = oldIndex;

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }*/
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
