using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    public InventoryUI inventoryUI;

    private Equipment equipment;
    public EquipUI equipmentUI;

    public StatsUI statsUI;

    public ButtonsUI buttons;

    public float speed;

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
            if(!inventory.InventoryFull()) PickUpItem(collision);
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
        MovementAndAnimaiton();
    }
    void MovementAndAnimaiton()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 movDir = new Vector3(x, y, 0).normalized;

        transform.position += movDir * speed * Time.deltaTime;

        Animator an = GetComponent<Animator>();

        if (movDir.y > 0.01f) an.Play("Up");
        else if (movDir.y < -0.01f) an.Play("Down");
        else if (movDir.x > 0.01f) an.Play("Right");
        else if (movDir.x < -0.01f) an.Play("Left");
        else an.Play("Idle");
    }
}
