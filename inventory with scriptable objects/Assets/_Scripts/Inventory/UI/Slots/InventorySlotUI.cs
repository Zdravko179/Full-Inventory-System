using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotUI : SlotUI
{
    public int slotIndex;
    //static int draggedSlotIndex;

    Inventory inventory;
    Equipment equipment;

    private void Awake()
    {
        equipment = FindObjectOfType<PlayerInventory>().equipment;
    }


    public void SetInventory(Inventory inventory) => this.inventory = inventory;
    public override void StartDrag()
    {
        DraggedItem.draggedSlotIndex = slotIndex;

        fromInventory = inventory;
        fromEquipment = null;

        DraggedItem.Instance.Activate(item, inventory);
    }
    public override void EndDrag() 
    {
        if (item == null) //not swap
        {
            if (fromEquipment != null)
            {
                inventory.AddItemAt(DraggedItem.item, slotIndex);
                fromEquipment.Unequip(DraggedItem.item);
            }
            if (fromInventory != null)
            {
                inventory.RemoveItem(DraggedItem.item);
                inventory.AddItemAt(DraggedItem.item, slotIndex);
            }
        }
        else //swap
        {
            if (fromEquipment != null) return; //prevent swaping when dragging from eqipment to inventory
            if (fromInventory != null)
            {
                Item thisItem = inventory.RemoveItem(item);
                inventory.AddItemAt(thisItem, DraggedItem.draggedSlotIndex);

                inventory.RemoveItem(DraggedItem.item);
                inventory.AddItemAt(DraggedItem.item, slotIndex);
            }
        }
    }
    protected override void DropItem()
    {
        inventory.RemoveItem(item);
    }
    public override void ConsumeItem()
    {
        inventory.ConsumeItem(item);
    }

    public override void EquipUnequip()
    {
        if (item.data.itemType == GlobalClass.ItemType.Helmet || item.data.itemType == GlobalClass.ItemType.BodyArmour || 
            item.data.itemType == GlobalClass.ItemType.Gauntlet || item.data.itemType == GlobalClass.ItemType.Accesory)
        {
            //DraggedItem.item = item;
            //DraggedItem.draggedSlotIndex = slotIndex;
            switch (item.data.itemType)
            {
                case GlobalClass.ItemType.Helmet:
                    if (FindObjectOfType<PlayerInventory>().equipment.head != null) 
                        inventory.AddItemAt(FindObjectOfType<PlayerInventory>().equipment.head, slotIndex);
                    break;
                case GlobalClass.ItemType.BodyArmour:
                    if (FindObjectOfType<PlayerInventory>().equipment.body != null)
                        inventory.AddItemAt(FindObjectOfType<PlayerInventory>().equipment.head, slotIndex);
                    break;
                case GlobalClass.ItemType.Gauntlet:
                    if (FindObjectOfType<PlayerInventory>().equipment.hands != null)
                        inventory.AddItemAt(FindObjectOfType<PlayerInventory>().equipment.head, slotIndex);
                    break;
                case GlobalClass.ItemType.Accesory:
                    if (FindObjectOfType<PlayerInventory>().equipment.accesory != null)
                        inventory.AddItemAt(FindObjectOfType<PlayerInventory>().equipment.head, slotIndex);
                    break;
            }

            equipment.Equip(item);
            inventory.RemoveItem(item);
        }
    }
}
