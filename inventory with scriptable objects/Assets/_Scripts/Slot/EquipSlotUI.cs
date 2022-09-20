using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlotUI : SlotUI, IItem
{
    public event EventHandler<OnItemDropedEventArgs> OnItemDropped;
    public class OnItemDropedEventArgs : EventArgs
    {
        public Item item;
    }

    public Sprite placeholder;
    public GlobalClass.ItemType slotType;

    public Equipment equipment;

    public Image image;
    //Color placeholderColor;


    public void SetEquipment(Equipment equipment) => this.equipment = equipment;
    private void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        image.sprite = placeholder;
        //GlobalClass.equipSlot = this;
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
    {
        if (slotType == GlobalClass.item.data.itemType)
        {
            equipment.EquipItem(item);
        }
        
        OnItemDropped?.Invoke(this, new OnItemDropedEventArgs { item = item });
    }
    public void AddItem(Item item)
    {

    }
    public void RemoveItem(Item item)
    {

    }
}