using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform SlotPanel;
    public GameObject pfSlot, pfItem;

    int numberOfSlots, rowSize;
    public Inventory inventory;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        numberOfSlots = 20;
        rowSize = 4;
        RefreshInventory();
        inventory.OnItemListChanged += OnItemListChanged;

    }

    private void OnItemListChanged(object sender, EventArgs e) => RefreshInventory();

    void RefreshInventory()
    {
        //-----------------------REMOVE OLD SLOTS------------------------//
        foreach (Transform slot in SlotPanel) //remove old
        {
            Destroy(slot.gameObject);
        }
        //-----------------------ADD SLOTS AND ITEMS------------------------//
        GameObject slotUI;
        GameObject[] slotsUI = new GameObject[numberOfSlots];
        for (int i = 0; i < numberOfSlots; i++) //create slots
        {
            slotUI = Instantiate(pfSlot, SlotPanel);
            slotUI.GetComponent<InventorySlotUI>().slotIndex = i;
            slotUI.GetComponent<InventorySlotUI>().SetInventory(inventory);
            slotsUI[i] = slotUI;
            foreach (Item item in inventory.GetItemList()) //create items
            {
                if (item.position == i)
                {
                    slotUI.GetComponent<SlotUI>().item = item;
                    GameObject instanceItem = Instantiate(pfItem, slotUI.transform);

                    instanceItem.GetComponent<Image>().sprite = item.data.sprite;
                    if (item.data.stackLimit >= 1000) instanceItem.transform.GetChild(0).GetComponent<Text>().text = item.ammount.ToString();
                    else if (item.data.stackLimit > 1) instanceItem.transform.GetChild(0).GetComponent<Text>().text = item.ammount + "/" + item.data.stackLimit;
                    else instanceItem.transform.GetChild(0).GetComponent<Text>().text = "";

                    break;
                }
            }
        }
        //-----------------------HIDE UNNECESSARY SLOTS------------------------//
        for (int i = numberOfSlots - 1; i >= 0; i--) //show all slots
        {
            slotsUI[i]?.SetActive(true);
        }
        for (int i=numberOfSlots-1; i>=0; i--)
        {
            int itemsInRow = 0;
            if (slotsUI[i].GetComponent<SlotUI>().item != null) itemsInRow++;
            if (i % 4 == 0)
            {
                if (itemsInRow != 0) break; //ckeck if item in row

                int otherEmptySlots = 0;
                for(int j=i-1; j>=0; j--) //check if any more empty slots
                {
                    //Debug.Log("check " + j);
                    if (slotsUI[i].GetComponent<SlotUI>().item == null) otherEmptySlots++;
                }
                //Debug.LogWarning(otherEmptySlots);

                if (otherEmptySlots == 0) break;

                for (int j = (i + rowSize-1); j >= i; j--) //hide slots
                {
                    slotsUI[j].SetActive(false);
                }
            }
        }
    }
}