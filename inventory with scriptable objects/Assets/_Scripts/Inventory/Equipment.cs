using System;
using UnityEngine;

public class Equipment
{
    public Item head, body, hands, accesory;
    public event EventHandler OnItemListChanged;

   
    public void Equip(Item item)
    {
        switch (item.data.itemType)
        {
            case GlobalClass.ItemType.Helmet:
                head = item;
                break;
            case GlobalClass.ItemType.BodyArmour:
                body = item;
                break;
            case GlobalClass.ItemType.Gauntlet:
                hands = item;
                break;
            case GlobalClass.ItemType.Accesory:
                accesory = item;
                break;
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public void Unequip(Item item)
    {
        switch (item.data.itemType)
        {
            case GlobalClass.ItemType.Helmet:
                head = null;
                break;
            case GlobalClass.ItemType.BodyArmour:
                body = null;
                break;
            case GlobalClass.ItemType.Gauntlet:
                hands = null;
                break;
            case GlobalClass.ItemType.Accesory:
                accesory = null;
                break;
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
}