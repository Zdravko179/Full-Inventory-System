using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipSlotUI_Y : MonoBehaviour, IPointerClickHandler
{
    //public int slotIndex;
    public Sprite placeholder;
    public GlobalClass_Y.ItemType slotType;

    public Item_Y item; //not in inspector
    Image image;
    Color placeholderColor;
    static GameObject itemUI;

    public Inventory_Y inventory;


    //public void SetInventory(Inventory_Y inventory) => this.inventory = inventory;
    private void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        image.sprite = placeholder;
        placeholderColor = GetComponent<Image>().color;

        inventory = FindObjectOfType<Player_Y>().inventory;
    }
    public void SetSprite(Item_Y item)
    {
        image.sprite = item.soItem.sprite;
    }
    public void RemoveSprite()
    {
        placeholder = item.soItem.sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) //start dragg
        {
            if (!GlobalClass_Y.dragging)
            {
                if (item == null)
                {
                    return;
                }
                itemUI = transform.GetChild(0).gameObject;
                itemUI.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
                ItemIcon_Y.Instance.Activate(item.soItem.sprite);
                //GlobalClass_Y.inventory = inventory;
                GlobalClass_Y.item = item;
                //draggedItemIndex = itemIndex;

                GlobalClass_Y.dragging = true;
            }
            else
            {
                if (eventData.button == PointerEventData.InputButton.Left) //add item / stop drag
                {
                    if (GlobalClass_Y.item.soItem.itemType == slotType)
                    {
                        item = GlobalClass_Y.item;
                        GlobalClass_Y.item = null;
                        //GlobalClass_Y.inventory.RemoveItem(item);
                        GlobalClass_Y.dragging = false;
                        image.sprite = item.soItem.sprite;
                        image.color = new Color(1, 1, 1, 1);
                        ItemIcon_Y.Instance.Deactivate();
                        inventory.AddItem(item.soItem.id);
                    }
                }
            }
        }

        if (GlobalClass_Y.dragging) return;

        if (eventData.button == PointerEventData.InputButton.Right) //remove item
        {
            //image.color = placeholderColor;
            image.color = new Color(placeholderColor.r, placeholderColor.g, placeholderColor.b, 0.2f);
            item = null;
        }
    }

    private void Update()
    {
        if (GlobalClass_Y.dragging && Input.GetMouseButtonDown(1) && GlobalClass_Y.item != null) //cancel dragging on right click
        {
            //inventory.MoveItem(GlobalClass_Y.item, GlobalClass_Y.item, draggedItemIndex, draggedItemIndex);
            /*
            itemUI.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            ItemIcon_Y.Instance.Deactivate();
            GlobalClass_Y.dragging = false;
            */
        }
    }
}
