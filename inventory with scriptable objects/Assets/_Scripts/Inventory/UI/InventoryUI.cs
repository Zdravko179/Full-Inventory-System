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

    private void Update()
    {
        if (Input.GetKey(KeyCode.C)) inventory.ClearInventory();
    }

    private void OnItemListChanged(object sender, EventArgs e) => RefreshInventory();
    public void OnEnableRefresh()
    {
        if (DraggedItem.dragging)
        {
            RefreshInventory();
            DraggedItem.Instance.Deactivate();
            Tooltip.Instance.Deactivate();
            DraggedItem.dragging = false;
        }
    }

    void RefreshInventory()
    {

        //-----------------------REMOVE OLD SLOTS------------------------//
        //Debug.LogWarning($"Number of items in invntory: {inventory.GetItemList().Count}");
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
                    slotUI.GetComponent<Image>().color = GetAmmountColor(slotUI.GetComponent<SlotUI>().item);
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
        int itemsInRow = 0;
        for (int i=numberOfSlots-1; i>=0; i--)
        {
            if (slotsUI[i].GetComponent<SlotUI>().item != null) itemsInRow++;
            if (i % 4 == 0)
            {
                if (itemsInRow > 0) break; //ckeck if item in row

                int otherEmptySlots = 0;
                for(int j=i-1; j>=0; j--) //check if any more empty slots
                {
                    if (slotsUI[j].GetComponent<SlotUI>().item == null) otherEmptySlots++;
                }

                if (otherEmptySlots == 0) break;

                for (int j = (i + rowSize-1); j >= i; j--) //hide slots
                {
                    slotsUI[j].SetActive(false);
                }

                itemsInRow = 0;
                otherEmptySlots = 0;
            }
        }
    }
    Color GetAmmountColor(Item item)
    {
        float percentage = ((float)item.ammount / (float)item.data.stackLimit);
        Color color = new Color(0f, 1f, 1 - percentage);
        return color;
    }
}