using System.Collections.Generic;
using System;
using UnityEngine;

public class Inventory_Y
{
    public List<Item_Y> itemList = new List<Item_Y>();
    public event EventHandler OnItemListChanged;

    
    public void AddItem(int id) => AddItem(id, 1);
    public void AddItem(int id, int ammount)
    {
        if (itemList.Count >= 20) Debug.Log("Invetory Full, Can't Add More Items");
        if (ammount > ItemDatabase_Y.Instance.FetchItemById(id).stackLimit)
        {
            Debug.Log("Adding more than stack limit");
            ammount = ItemDatabase_Y.Instance.FetchItemById(id).stackLimit;
        }

        foreach (Item_Y item in itemList) //fill existing stacks
        {
            if (item.soItem == ItemDatabase_Y.Instance.FetchItemById(id))
            {
                while (ammount > 0 && item.ammount < item.soItem.stackLimit)
                {
                    item.ammount++;
                    ammount--;
                }
            }
        }

        if (ammount != 0) //add new stack
        {
            Item_Y item = new Item_Y();
            for (int i = 0; i < 20; i++) //set index to 1st index that doesn't exsist
            {
                bool found = false;
                foreach (Item_Y it in itemList)
                {
                    if (it.index == i) found = true;
                }
                if (!found)
                {
                    item.index = i;
                    break;
                }
            }
            if (ItemDatabase_Y.Instance.FetchItemById(id) == null) Debug.Log("Item not found in database");
            else item.soItem = ItemDatabase_Y.Instance.FetchItemById(id);
            item.ammount = ammount;
            itemList.Add(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public Item_Y AddItemAt(Item_Y item, int index)
    {
        itemList.Add(item);
        item.index = index;

        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        return item;
    }/*
    public void MoveItem(Item_Y oldItem, int newIndex)
    {
        MoveItem(oldItem, null, 0, newIndex);
    }
    public void MoveItem(Item_Y oldItem, Item_Y newItem, int oldIndex, int newIndex)
    {
        oldItem.index = newIndex;
        if (newItem != null) newItem.index = oldIndex;

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public void RemoveItem(Item_Y item)
    {
        itemList.Remove(item);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }*/
    public int GetLength()
    {
        return itemList.Count;
    }
    
}
public class Item_Y
{
    public int index { get; set; }
    public ItemZ soItem { get; set; }
    public int ammount { get; set; }
}
