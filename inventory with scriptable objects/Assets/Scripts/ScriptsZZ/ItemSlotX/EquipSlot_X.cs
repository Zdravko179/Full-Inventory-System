using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot_X : SlotUI_X
{
    public event EventHandler<OnItemDropedEventArgs> OnItemDropped;
    public class OnItemDropedEventArgs : EventArgs
    {
        public Item_Y item;
    }

    public Sprite placeholder;
    public GlobalClass_Y.ItemType slotType;

    public Inventory_Y inventory;

    public Image image;
    //Color placeholderColor;

    private void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        image.sprite = placeholder;
        GlobalClass_Y.equipSlot = this;
        //placeholderColor = GetComponent<Image>().color;
    }
    public void SetDefault()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        image.sprite = placeholder;
        image.color = new Color(1, 1, 1, 0.2f);
        item = null;
    }
    public override void StartDrag()
    {
    }
    public override void EndDrag() 
    {/*
        if (GlobalClass_Y.item.soItem.itemType == slotType)
        {
            inventory.RemoveItem(GlobalClass_Y.item);

            item = GlobalClass_Y.item;
            image.color = new Color(1, 1, 1, 1);
            image.sprite = GlobalClass_Y.item.soItem.sprite;
        }*/
        OnItemDropped?.Invoke(this, new OnItemDropedEventArgs { item = item });
    }
    public override void SetSlotItem()
    {
        
    }
    public override void DeleteSlotItem()
    {
        
    }
}