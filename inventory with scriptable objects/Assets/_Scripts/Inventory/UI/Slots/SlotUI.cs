using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class SlotUI : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{ 
    public Item item;
    protected static GameObject itemUI; //only to set transparency

    protected static Inventory fromInventory = null;
    protected static Equipment fromEquipment = null; 


    public abstract void StartDrag(); public abstract void EndDrag(); protected abstract void DropItem(); public abstract void EquipUnequip();
    public abstract void ConsumeItem();
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!DraggedItem.dragging) //start drag
            {
                if (item == null) return;

                itemUI = transform.GetChild(0).gameObject;
                itemUI.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);

                DraggedItem.item = item;
                DraggedItem.dragging = true;

                

                StartDrag();
            }
            else //end drag
            {
                if (itemUI != null) itemUI.GetComponent<Image>().color = new Color(1, 1, 1, 1);

                DraggedItem.dragging = false;

                DraggedItem.Instance.Deactivate();

                EndDrag();
            }
        }

        if (DraggedItem.dragging || item == null) return;

        if (Input.GetKey(KeyCode.LeftControl) && eventData.button == PointerEventData.InputButton.Right) //drop item
        {
            SpawnItemWorld.Instance.DropItem(item);
            DropItem();
            Tooltip.Instance.Deactivate();
        }

        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            EquipUnequip();
            Tooltip.Instance.Deactivate();
        }

        else if (eventData.button == PointerEventData.InputButton.Middle) //consume item
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
        if (DraggedItem.dragging && DraggedItem.item != null) //cancel dragging on right click
        {
            if (itemUI != null) itemUI.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            DraggedItem.Instance.Deactivate();
            DraggedItem.dragging = false;
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
