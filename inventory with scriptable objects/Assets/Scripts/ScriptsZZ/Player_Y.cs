using UnityEngine;

public class Player_Y : MonoBehaviour
{
    public InventoryUI_Y inventoryUI;
    public Inventory_Y inventory;

    private void Awake()
    {
        inventory = new Inventory_Y();
        foreach (EquipSlot_X slot in FindObjectsOfType<EquipSlot_X>()) { slot.inventory = inventory; }
        inventoryUI.SetInventory(inventory);
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
        }
            inventory.AddItem(2, 3);
            inventory.AddItem(6, 6);
            inventory.AddItem(3, 6);
            inventory.AddItem(6, 6);
            inventory.AddItem(2, 100);
            inventory.AddItem(2, 100);
            inventory.AddItem(2, 100);
            inventory.AddItem(4, 1);
            inventory.AddItem(4, 1);
            inventory.AddItem(4, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ItemWorld_Y>() != null)
        {
            PickUpItem(collision);
        }
    }
    void PickUpItem(Collider2D collision)
    {
        ItemWorld_Y itemWorld = collision.GetComponent<ItemWorld_Y>();
        inventory.AddItem(itemWorld.id, itemWorld.ammount);
        Destroy(collision.gameObject);
    }
}
