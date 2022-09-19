using UnityEngine;

public class GlobalClass_Y : MonoBehaviour
{
    public enum ItemType
    {
        None,
        Helmet,
        BodyArmour,
        Gauntlet,
        Accesory,
        Usable,
        NonUsable
    }
    public static ItemType itemType;

    public static Inventory_Y inventory;
    public static Item_Y item;
    public static bool dragging;

    public static bool movedFromInventory;
    public static EquipSlot_X equipSlot;

    private void Awake()
    {
        inventory = null;
        item = null;
        dragging = false;

        movedFromInventory = true;
    }
}
