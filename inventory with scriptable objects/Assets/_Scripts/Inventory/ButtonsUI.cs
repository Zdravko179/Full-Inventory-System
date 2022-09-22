using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonsUI : MonoBehaviour
{
    [SerializeField] private GameObject inventory, equipment, stats;
    Player player;

    public void SetPlayer(Player player) => this.player = player;
   
    public void _SortItems() {
        player.inventory.SortItems();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) InventoryUI();
        if (Input.GetKeyDown(KeyCode.O)) EquipUI();
        if (Input.GetKeyDown(KeyCode.P)) StatsUI();
    }
    public void InventoryUI()
    {
        ShowHide(inventory);

        inventory.GetComponent<InventoryUI>().OnEnableRefresh();
        equipment.GetComponent<EquipUI>().OnEnableRefresh();
    }
    public void EquipUI()
    {
        ShowHide(equipment);

        inventory.GetComponent<InventoryUI>().OnEnableRefresh();
        equipment.GetComponent<EquipUI>().OnEnableRefresh();
    }
    public void StatsUI()
    {
        ShowHide(stats);
    }

    void ShowHide(GameObject obj)
    {
        if (obj.transform.localScale.x == 0)//show
        {
            obj.transform.localScale = Vector3.zero;
            obj.transform.DOScale(1, 0.1f).SetEase(Ease.OutSine);
        }
        if (obj.transform.localScale.x == 1)//hide
        {
            obj.transform.localScale = Vector3.one;
            obj.transform.DOScale(0, 0.1f).SetEase(Ease.InSine);
        }
    }
}
