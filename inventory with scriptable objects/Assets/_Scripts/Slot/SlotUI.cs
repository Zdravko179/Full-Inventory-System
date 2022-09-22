using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class SlotUI : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{ 
    public Item item;
    protected static GameObject itemUI; //only to set transparency

    protected static Inventory fromInventory = null;
    protected static Equipment fromEquipment = null; 


    public abstract void StartDrag(); public abstract void EndDrag(); protected abstract void DropItem();
    public abstract void ConsumeItem();
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
                if (itemUI != null) itemUI.GetComponent<Image>().color = new Color(1, 1, 1, 1);

                GlobalClass.dragging = false;

                DraggedItem.Instance.Deactivate();

                EndDrag();
            }
        }

        if (GlobalClass.dragging) return;

        if (Input.GetKey(KeyCode.LeftControl) && eventData.button == PointerEventData.InputButton.Right)
        {
            if (item == null) return;
            DropItem();
            Tooltip.Instance.Deactivate();
        }

        if (eventData.button == PointerEventData.InputButton.Middle)
        {
            if (item.data.itemType == GlobalClass.ItemType.Usable)
            {
                ConsumeItem();
                Tooltip.Instance.Deactivate();
            }
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) CancelDrag();   
    }
    void CancelDrag()
    {
        if (GlobalClass.dragging && GlobalClass.item != null) //cancel dragging on right click
        {
            if (itemUI != null) itemUI.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            DraggedItem.Instance.Deactivate();
            GlobalClass.dragging = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item == null) return;
        Tooltip.Instance.Activate(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (item == null) return;
        Tooltip.Instance.Deactivate();
    }
}
