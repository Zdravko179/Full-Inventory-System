using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class SlotUI : MonoBehaviour, IPointerDownHandler
{
    public Item item;
    private static GameObject itemUI; //only to set transparency


    public abstract void StartDrag(); public abstract void EndDrag();
    public abstract void SetSlotItem(); public abstract void DeleteSlotItem();
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!GlobalClass.dragging) //start drag
            {
                if (item == null) return;

                itemUI = transform.GetChild(0).gameObject;
                itemUI.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);

                GlobalClass.item = item;
                GlobalClass.dragging = true;

                DraggedItem.Instance.Activate(item.data.sprite);

                StartDrag();
            }
            else //end drag
            {
                //this shoud be done only if item can go in that slot or can swap
                if (itemUI != null) itemUI.GetComponent<Image>().color = new Color(1, 1, 1, 1);

                item = GlobalClass.item;
                GlobalClass.item = null;
                GlobalClass.dragging = false;

                DraggedItem.Instance.Deactivate();

                EndDrag();
            }
        }

        if (GlobalClass.dragging) return;

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
        if (GlobalClass.dragging && Input.GetMouseButtonDown(1) && GlobalClass.item != null) //cancel dragging on right click
        {
            if (itemUI != null) itemUI.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            DraggedItem.Instance.Deactivate();
            GlobalClass.dragging = false;
        }
    }
}