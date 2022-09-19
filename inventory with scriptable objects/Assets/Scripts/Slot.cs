
/// has: id, onItemDroped()

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
/*
public class Slot : MonoBehaviour, IDropHandler
{
	public int id;
	private Inventory inv;

	void Start()
	{
		inv = GameObject.Find("Inventory").GetComponent<Inventory>();
	}

	public void OnDrop(PointerEventData eventData) //on drop item in this slot
	{
		ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>(); //item thats beeing dragged
		if (inv.items[id].Id == -1) //drop on empty slot
		{
			inv.items[droppedItem.slotId] = new Item(); //make prevous slot empty
			inv.items[id] = droppedItem.item; //asign item to "this" slot
			droppedItem.slotId = id; //change items id to "this" slot
		}
		else if(droppedItem.slotId != id) //swamp items (if not dragged on self)
		{
			Transform item = this.transform.GetChild(0); //move this item to other slot
			item.GetComponent<ItemData>().slotId = droppedItem.slotId;
			item.transform.SetParent(inv.slots[droppedItem.slotId].transform);
			item.transform.position = inv.slots[droppedItem.slotId].transform.position;

			droppedItem.slotId = id; //move other item to this slot
			droppedItem.transform.SetParent(this.transform);
			droppedItem.transform.position = this.transform.position;

			inv.items[droppedItem.slotId] = item.GetComponent<ItemData>().item; //set items in inventory
			inv.items[id] = droppedItem.item;
		}
	}
}*/