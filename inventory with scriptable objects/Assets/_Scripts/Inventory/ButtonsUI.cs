using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsUI : MonoBehaviour
{
    [SerializeField] private GameObject inventory, equipment, stats;
    Player player;

    public void SetPlayer(Player player) => this.player = player;
    public void _Activation(GameObject obj)
    {
        obj.SetActive(obj.activeSelf ? false : true);
    }
    public void _SortItems() {
        player.inventory.SortItems();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(inventory.activeSelf ? false : true);
            inventory.GetComponent<InventoryUI>().OnEnableRefresh();
            equipment.GetComponent<EquipUI>().OnEnableRefresh();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            equipment.SetActive(equipment.activeSelf ? false : true);
            inventory.GetComponent<InventoryUI>().OnEnableRefresh();
            equipment.GetComponent<EquipUI>().OnEnableRefresh();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            stats.SetActive(stats.activeSelf ? false : true);
        }
    }
}
