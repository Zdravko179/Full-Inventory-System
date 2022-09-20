using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    public InventoryUI inventoryUI;

    private Equipment equipment;
    public EquipUI equipmentUI;

    public float speed;

    private void Awake()
    {
        inventory = new Inventory();
        inventoryUI.SetInventory(inventory);

        equipment = new Equipment();
        equipmentUI.SetEquipment(equipment);
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
        }
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
        inventory.AddItemById(itemWorld.id, itemWorld.ammount);
        Destroy(collision.gameObject);
    }
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 movDir = new Vector3(x, y, 0).normalized;

        transform.position += movDir * speed * Time.deltaTime;
    }
}
