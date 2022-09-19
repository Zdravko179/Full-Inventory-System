using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class EquipSlotUiZ : MonoBehaviour, IDropHandler
{
	//public int slotId;
	public GlobalClass_Y.ItemType slotType;
	//private InventoryZ inv;


	public void OnDrop(PointerEventData eventData)
	{
		ItemUiZ droppedItem = eventData.pointerDrag.GetComponent<ItemUiZ>();

		if (droppedItem.item.itemType == slotType)
        {
			Debug.Log(droppedItem.item.itemType);
			droppedItem.transform.SetParent(this.transform);
			droppedItem.transform.position = this.transform.position;
		}
	}
}