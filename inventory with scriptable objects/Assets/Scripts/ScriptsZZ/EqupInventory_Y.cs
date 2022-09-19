using UnityEngine;

public class EqupInventory_Y : MonoBehaviour
{
    EquipSlotUI_Y head, body, gauntlets, accesory;

    private void Start()
    {
        head = transform.GetChild(0).GetComponent<EquipSlotUI_Y>();
        body = transform.GetChild(1).GetComponent<EquipSlotUI_Y>();
        gauntlets = transform.GetChild(2).GetComponent<EquipSlotUI_Y>();
        accesory = transform.GetChild(3).GetComponent<EquipSlotUI_Y>();
    }
}
