using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoramlSlot_X : SlotUI_X
{
    public int slotIndex;
    Inventory_Y inventory;
    static int draggedslotIndex;


    public void SetInventory(Inventory_Y inventory) => this.inventory = inventory;
    public override void StartDrag()
    {
        draggedslotIndex = slotIndex;
    }
    public override void EndDrag() 
    {/*
        if (item != null) //swap
        {
            inventory.MoveItem(GlobalClass_Y.item, item, draggedslotIndex, slotIndex);
        }
        else //not swap
        {
            if (GlobalClass_Y.movedFromInventory)
                inventory.MoveItem(GlobalClass_Y.item, slotIndex);
            else
            {
                inventory.AddItemAt(GlobalClass_Y.item, slotIndex);

                GlobalClass_Y.equipSlot.SetDefault();
            }
        }*/
    }
    public override void SetSlotItem()
    {
        
    }
    public override void DeleteSlotItem()
    {
       
    }
}
