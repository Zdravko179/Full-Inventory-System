using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory { get; private set; }
    public InventoryUI inventoryUI;
    public Equipment equipment { get; private set; }
    public EquipUI equipmentUI;
    public StatsUI statsUI;
    public ButtonsUI buttons;


    private void Awake()
    {
        inventory = new Inventory();
        inventoryUI.SetInventory(inventory);
        equipment = new Equipment();
        equipmentUI.SetEquipment(equipment);
        statsUI.SetEquipment(equipment);
        buttons.SetPlayer(this);
    }

    private void Start()
    {
        inventory.AddItemById(2, 3);
        inventory.AddItemById(6, 6);
        inventory.AddItemById(3, 6);
        inventory.AddItemById(6, 6);
        inventory.AddItemById(2, 100);
        inventory.AddItemById(2, 100);
        inventory.AddItemById(2, 100);
        inventory.AddItemById(4, 1);
        inventory.AddItemById(4, 1);
        inventory.AddItemById(4, 1);
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
        inventory.AddItemById(itemWorld.id, itemWorld.ammount, itemWorld);
    }
}
