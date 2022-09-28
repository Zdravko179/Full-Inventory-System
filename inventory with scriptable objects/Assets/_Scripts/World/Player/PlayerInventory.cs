using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;

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
        GetComponent<ItemPickUp>().SetInventory(inventory);
    }

    private void Start()
    {
        for (int i = 0; i < ItemDatabase.Instance.itemDatas.Length; i++)
        {
            inventory.AddItemById(i);
        }
        inventory.PermaUpgrade += PermaUpgrade;
    }
    private void PermaUpgrade(object sender, EventArgs e)
    {
        Color pink = new Color(1, 0, 1);
        GetComponent<SpriteRenderer>().DOColor(pink, .1f).SetLoops(4, LoopType.Yoyo);
        StartCoroutine(RevertColor());
    }
    IEnumerator RevertColor()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
