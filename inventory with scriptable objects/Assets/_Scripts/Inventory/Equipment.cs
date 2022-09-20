using System;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public Item head, body, hands, accesory;
    public event EventHandler OnItemListChanged;

   
    public void EquipItem(Item item)
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
}