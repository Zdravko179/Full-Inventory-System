using UnityEngine;
using UnityEngine.EventSystems;

public class ItemUiZ : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	[HideInInspector]public ItemZ item;
	public int amount;
	public int itemId;

	private InventoryZ inv;
	private TooltipZ tooltip;
	private Vector3 offset;

	bool draggingThis;

	void Start()
	{
		inv = GameObject.Find("InventoryZ").GetComponent<InventoryZ>();
		tooltip = inv.GetComponent<TooltipZ>();
	}
	
	public void OnBeginDrag(PointerEventData eventData)
	{
		if (item != null)
		{
			this.transform.SetParent(this.transform.parent.parent.parent.parent);
			this.transform.position = eventData.position - (Vector2)offset;
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}

    public void OnDrag(PointerEventData eventData)
    {
		this.transform.position = eventData.position - (Vector2)offset;
	}

    public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log("end drag");
		
		this.transform.SetParent(inv.slotList[itemId].transform); //id was changed by onDrop() in SlotUi
		this.transform.position = inv.slotList[itemId].transform.position;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		
	}
	/*
	public void OnPointerDown(PointerEventData eventData)
	{
		if (Input.GetMouseButton(0))
        {
			if (GlobalFuncsZ.dragging == false)
            {
				GlobalFuncsZ.dragging = true;
				draggingThis = true;
            }
        }

		if (draggingThis)
        {
			Debug.Log("start drag");
			this.transform.SetParent(this.transform.parent.parent.parent.parent);
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
        else
        {
			Debug.Log("end drag");
			this.transform.SetParent(inv.slotList[itemId].transform);
			this.transform.position = inv.slotList[itemId].transform.position;
			GetComponent<CanvasGroup>().blocksRaycasts = true;
		}
		
		if (!GlobalFuncsZ.dragging) return;

		//Debug.Log("can drop it");

		if (Input.GetMouseButton(0)) //drag
        {
			//draggingThis = draggingThis ? false : true;
			//offset = eventData.position - (Vector2)this.transform.position;

		}
		if (Input.GetMouseButton(1)) //drop
        {
			inv.RemoveItem(this.gameObject, itemId);
        }
	}
    private void Update()
    {
		if (!draggingThis) return;
		if (item != null)
		{
			this.transform.position = Input.mousePosition/* - offset;
		}
	}*/

    public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.Activate(item);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.Deactivate();
	}
}