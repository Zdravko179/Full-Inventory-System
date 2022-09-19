using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class SlotUI_X : MonoBehaviour, IPointerDownHandler
{
    public Item_Y item;
    private static GameObject itemUI; //only to set transparency


    public abstract void StartDrag(); public abstract void EndDrag();
    public abstract void SetSlotItem(); public abstract void DeleteSlotItem();
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!GlobalClass_Y.dragging) //start drag
            {
                if (item == null) return;

                itemUI = transform.GetChild(0).gameObject;
                itemUI.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);

                GlobalClass_Y.item = item;
                GlobalClass_Y.dragging = true;

                ItemIcon_Y.Instance.Activate(item.soItem.sprite);

                StartDrag();
            }
            else //end drag
            {
                //this shoud be done only if item can go in that slot or can swap
                if (itemUI != null) itemUI.GetComponent<Image>().color = new Color(1, 1, 1, 1);

                item = GlobalClass_Y.item;
                GlobalClass_Y.item = null;
                GlobalClass_Y.dragging = false;

                ItemIcon_Y.Instance.Deactivate();

                EndDrag();
            }
        }

        if (GlobalClass_Y.dragging) return;

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //inventory.RemoveItem(item);
        }
    }
    private void Update()
    {
        //CancelDrag();   
    }
    void CancelDrag()
    {
        if (GlobalClass_Y.dragging && Input.GetMouseButtonDown(1) && GlobalClass_Y.item != null) //cancel dragging on right click
        {
            if (itemUI != null) itemUI.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            ItemIcon_Y.Instance.Deactivate();
            GlobalClass_Y.dragging = false;
        }
    }
}
