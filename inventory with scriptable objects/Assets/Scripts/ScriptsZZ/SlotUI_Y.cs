using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotUI_Y : MonoBehaviour, IPointerDownHandler
{
    public int slotIndex;
    Inventory_Y inventory;
    public Item_Y item;

    static GameObject itemUI;
    static int draggedslotIndex;


    public void SetInventory(Inventory_Y inventory) => this.inventory = inventory;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!GlobalClass_Y.dragging) //start drag
            {
                if (transform.childCount == 0)
                {
                    return;
                }
                itemUI = transform.GetChild(0).gameObject;
                itemUI.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
                ItemIcon_Y.Instance.Activate(item.soItem.sprite);
                GlobalClass_Y.inventory = inventory;
                GlobalClass_Y.item = item;
                draggedslotIndex = slotIndex;

                GlobalClass_Y.dragging = true;
            }
            else //end drag
            {
                if (itemUI != null)
                    itemUI.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                ItemIcon_Y.Instance.Deactivate();
                if (item != null) //swap
                {
                    Debug.Log("swap placement");
                    //inventory.MoveItem(GlobalClass_Y.item, item, draggedslotIndex, transform.GetComponent<SlotUI_Y>().slotIndex);
                }
                else //not swap
                {
                    Debug.Log("not-swap placement: " + GlobalClass_Y.item.soItem.name + " to " + slotIndex);
                    //inventory.MoveItem(GlobalClass_Y.item, null, 0, slotIndex);
                }

                GlobalClass_Y.dragging = false;
            }
        }

        if (GlobalClass_Y.dragging) return; //can't do other code because it's GlobalClass_Y.dragging

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //inventory.RemoveItem(item);
        }
    }
    private void Update()
    {
        if (GlobalClass_Y.dragging && Input.GetMouseButtonDown(1) && GlobalClass_Y.item != null) //cancel dragging on right click
        {
            //inventory.MoveItem(GlobalClass_Y.item, GlobalClass_Y.item, draggedslotIndex, draggedslotIndex);
            ItemIcon_Y.Instance.Deactivate();
            GlobalClass_Y.dragging = false;
        }
    }
}
