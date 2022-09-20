using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotUI : SlotUI, IItem
{
    public int slotIndex;
    Inventory inventory;
    static int draggedSlotIndex;


    public void SetInventory(Inventory inventory) => this.inventory = inventory;
    public override void StartDrag()
    {
        draggedSlotIndex = slotIndex;
    }
    public override void EndDrag() 
    {
        if (item == null) //not swap
        {
            inventory.AddItemAt(GlobalClass.item, slotIndex);
        }
        else //swap
        {
            inventory.AddItemAt(item, draggedSlotIndex);
            inventory.AddItemAt(GlobalClass.item, slotIndex);
        }
    }
    public void AddItem(Item item)
    {

    }
    public void RemoveItem(Item item)
    {

    }
}
