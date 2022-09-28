using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections;


public class DraggedItem : MonoBehaviour
{
    public static DraggedItem Instance;
    Image image;

    public static Item item;
    public Inventory inventory = null; 
    public Equipment equipment = null;
    public static bool dragging;

    public static int draggedSlotIndex;


    private void Awake()
    {
        Instance = this;
        image = GetComponent<Image>();

        item = null;
        dragging = false;
    }
    private void Start()
    {
        Deactivate();
    }
    void Update()
    {
        transform.position = Input.mousePosition;
        //if (Input.GetMouseButtonDown(0)) DropItemOnMouseClick();
    }

    public void Activate(Item item, Inventory inventory)
    {
        Activate(item, inventory, null);
    }
    public void Activate(Item item, Equipment equipment)
    {
        Activate(item, null, equipment);
    }
    private void Activate(Item item, Inventory inventory, Equipment equipment)
    {
        if (image == null) return;
        image.sprite = item.data.sprite;
        image.color = new Color(1, 1, 1, 1);

        this.inventory = inventory;
        this.equipment = equipment;
    }
    public void Deactivate()
    {
        if (image == null) return;
        image.color = new Color(1, 1, 1, 0);
    }

    void DropItemOnMouseClick()
    {
        if (item == null) return;
        if (!dragging) return;
        if (EventSystem.current.IsPointerOverGameObject()) return; //continue if not over UI
        
        if (inventory != null) inventory.RemoveItem(item);
        if (equipment != null) equipment.Unequip(item);

        SpawnItemWorld.Instance.DropItem(item);
        Deactivate();
        //item = null;
        dragging = false;
    }
}
