using UnityEngine;

public class GlobalClass : MonoBehaviour
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

    public static Inventory inventory;
    public static Item item;
    public static bool dragging;

    public static bool movedFromInventory;
    public static EquipSlot equipSlot;

    private void Awake()
    {
        inventory = null;
        item = null;
        dragging = false;

        movedFromInventory = true;
    }
}
