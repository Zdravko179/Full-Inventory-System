using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlotUI : SlotUI
{
    public class OnItemDropedEventArgs : EventArgs
    {
        public Item item;
    }

    public Sprite placeholder;
    public GlobalClass.ItemType slotType;

    public Equipment equipment;

    //public Image image;
    //Color placeholderColor;


    public void SetEquipment(Equipment equipment) => this.equipment = equipment;

    public override void StartDrag()
    {
        fromInventory = null;
        fromEquipment = equipment;
    }
    public override void EndDrag() 
    {
        if (slotType == GlobalClass.item.data.itemType)
        {
            if (fromInventory != null) fromInventory.RemoveItem(GlobalClass.item);
            equipment.Equip(GlobalClass.item);
            item = GlobalClass.item;
        }
    }
    protected override void DropItem()
    {
        equipment.Unequip(item);
    }
    public override void ConsumeItem() {}
}