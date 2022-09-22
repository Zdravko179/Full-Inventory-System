using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotUI : SlotUI
{
    public int slotIndex;
    Inventory inventory;
    static int draggedSlotIndex;


    public void SetInventory(Inventory inventory) => this.inventory = inventory;
    public override void StartDrag()
    {
        draggedSlotIndex = slotIndex;

        fromInventory = inventory;
        fromEquipment = null;
    }
    public override void EndDrag() 
    {
        if (item == null) //not swap
        {
            if (fromEquipment != null)
            {
                inventory.AddItemAt(GlobalClass.item, slotIndex);
                fromEquipment.Unequip(GlobalClass.item);
            }
            if (fromInventory != null)
            {
                inventory.RemoveItem(GlobalClass.item);
                inventory.AddItemAt(GlobalClass.item, slotIndex);
            }
        }
        else //swap
        {
            if (fromEquipment != null) return; //prevent swaping when dragging from eqipment to inventory
            if (fromInventory != null)
            {
                Item thisItem = inventory.RemoveItem(item);
                inventory.AddItemAt(thisItem, draggedSlotIndex);

                inventory.RemoveItem(GlobalClass.item);
                inventory.AddItemAt(GlobalClass.item, slotIndex);
            }
        }
    }
    protected override void DropItem()
    {
        SpawnItemWorld.Instance.DropItem(item);
        inventory.RemoveItem(item);
    }
    public override void ConsumeItem()
    {
        inventory.ConsumeItem(item);
    }
}
