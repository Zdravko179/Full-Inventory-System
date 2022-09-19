using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class SlotUiZ : MonoBehaviour, IDropHandler
{
	public int slotId;
	private InventoryZ inv;
	[HideInInspector] public ItemUiZ itemUiZ;


	void Start()
	{
		inv = GameObject.Find("InventoryZ").GetComponent<InventoryZ>();
	}

	
	public void OnDrop(PointerEventData eventData)
	{
		
		Debug.Log("on-drop");
		
		ItemUiZ droppedItem = eventData.pointerDrag.GetComponent<ItemUiZ>();

		if (inv.itemList[slotId] == null) //drop on empty slot
		{
			inv.itemList[droppedItem.itemId] = null; //old item

			inv.itemList[slotId] = droppedItem.item; //new item

			droppedItem.itemId = slotId;			 //new item id
		}
		else if (droppedItem.itemId != slotId) //swamp items (if not dragged on self)
		{
			Transform item = this.transform.GetChild(0); //move this item to other slot
			item.GetComponent<ItemUiZ>().itemId = droppedItem.itemId;
			item.transform.SetParent(inv.slotList[droppedItem.itemId].transform);
			item.transform.position = inv.slotList[droppedItem.itemId].transform.position;

			droppedItem.itemId = slotId; //move other item to this slot
			droppedItem.transform.SetParent(this.transform);
			droppedItem.transform.position = this.transform.position;

			inv.itemList[droppedItem.itemId] = item.GetComponent<ItemUiZ>().item; //set items in inventory
			inv.itemList[slotId] = droppedItem.item;
		}
	}
	/*
    public void OnPointerDown(PointerEventData eventData)
    {
		if (GlobalFuncsZ.dragging == true)
		{
			GlobalFuncsZ.dragging = true;
			draggingThis = true;
		}
	}*/
}