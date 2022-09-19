using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory();
        foreach (EquipSlot slot in FindObjectsOfType<EquipSlot>()) { slot.inventory = inventory; }
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
        if (collision.GetComponent<ItemWorld>() != null)
        {
            PickUpItem(collision);
        }
    }
    void PickUpItem(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        inventory.AddItem(itemWorld.id, itemWorld.ammount);
        Destroy(collision.gameObject);
    }
}
