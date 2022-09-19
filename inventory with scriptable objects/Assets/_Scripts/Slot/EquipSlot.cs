using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot : SlotUI
{
    public event EventHandler<OnItemDropedEventArgs> OnItemDropped;
    public class OnItemDropedEventArgs : EventArgs
    {
        public Item item;
    }

    public Sprite placeholder;
    public GlobalClass.ItemType slotType;

    public Inventory inventory;

    public Image image;
    //Color placeholderColor;

    private void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        image.sprite = placeholder;
        GlobalClass.equipSlot = this;
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