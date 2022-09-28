using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlotUI : SlotUI
{
    //public Sprite placeholder;
    public GlobalClass.ItemType slotType;

    public Equipment equipment; //try make this private
    Inventory inventory;

    private void Awake()
    {
        inventory = FindObjectOfType<PlayerInventory>().inventory;
    }


    public void SetEquipment(Equipment equipment) => this.equipment = equipment;

    public override void StartDrag()
    {
        fromInventory = null;
        fromEquipment = equipment;

        DraggedItem.Instance.Activate(item, equipment);
    }
    public override void EndDrag() 
    {
        if (slotType == DraggedItem.item.data.itemType)
        {
            if (item != null) inventory.AddItemAt(item, DraggedItem.draggedSlotIndex);

            if (fromInventory != null) fromInventory.RemoveItem(DraggedItem.item);
            equipment.Equip(DraggedItem.item);
            item = DraggedItem.item;
        }
    }
    protected override void DropItem()
    {
        equipment.Unequip(item);
    }
    public override void ConsumeItem() {}

    public override void EquipUnequip()
    {
        if (inventory.InventoryFull()) return;
        inventory.AddItemById(item.data.id);
        equipment.Unequip(item);
    }
}