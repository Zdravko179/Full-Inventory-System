using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemZZ
{
	int index;
	ItemZ item;
	int ammount;
}
public class InventoryZ : MonoBehaviour
{
	GameObject inventoryPanel;
	GameObject slotPanel;
	ItemDatabaseZ database;
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	private int slotAmount = 20;
	public ItemZ[] itemList;
	public List<GameObject> slotList = new List<GameObject>();

	public List<ItemZZ> itemListZZ;

	void Start()
	{
		itemList = new ItemZ[20];
		database = GetComponent<ItemDatabaseZ>();
		inventoryPanel = GameObject.Find("InventoryPanelZ");
		slotPanel = inventoryPanel.transform.Find("SlotPanelZ").gameObject; 

		for (int i = 0; i < slotAmount; i++)
		{
			slotList.Add(Instantiate(inventorySlot));
			slotList[i].GetComponent<SlotUiZ>().slotId = i;
			slotList[i].transform.SetParent(slotPanel.transform);
		}

		int itemCount = ItemDatabaseZ.Instance.itemDatas.Length;

		for (int i = 0; i < 1; i++)
        {
			for (int j = 0; j < itemCount; j++) 
				AddItem(j);
        }
	}
    public void AddItem(int id)
    {
		AddItem(id, 1);
    }
	public void AddItem(int id, int amount)
	{
		ItemZ itemToAdd = database.FetchItemById(id);

		if (amount > itemToAdd.stackLimit) amount = itemToAdd.stackLimit;

		for (int i = 0; i < itemList.Length; i++) //napuni sve stackove koji postoje
		{
			if (itemList[i] == null) continue;
			if (itemList[i].id == id)
			{
				if (slotList[i].transform.GetChild(0).GetComponent<ItemUiZ>() == null) return;

				ItemUiZ itemUI = slotList[i].transform.GetChild(0).GetComponent<ItemUiZ>();

				while (itemUI.amount < itemToAdd.stackLimit)
				{
					itemUI.amount++;
					amount--;

					itemUI.transform.GetChild(0).GetComponent<Text>().text = itemUI.amount.ToString();
					if (amount == 0) break;
                }
			}
		}
		if (amount != 0)  //dodaj item u novi slot ako postojeæi stackovi nisu bili dovoljni
		{
			for (int i = 0; i < 20; i++)
			{
				if (itemList[i] == null)
				{
					itemList[i] = itemToAdd;
					GameObject itemObj = Instantiate(inventoryItem);
					itemObj.GetComponent<ItemUiZ>().item = itemToAdd;	
					itemObj.GetComponent<ItemUiZ>().itemId = i;

					itemObj.GetComponent<ItemUiZ>().amount = amount;
					itemObj.transform.GetChild(0).GetComponent<Text>().text = amount.ToString();

					itemObj.transform.SetParent(slotList[i].transform);
					itemObj.transform.localPosition = Vector2.zero;
					itemObj.GetComponent<Image>().sprite = itemToAdd.sprite;
					break;
				}
			}
		}
		ExpandInventory();
	}
	public void RemoveItem(GameObject item, int slotId)
    {
		Destroy(item);
		itemList[slotId] = null;
		FindObjectOfType<TooltipZ>().Deactivate();
		ExpandInventory();
	}

	//check all active slots - if full - activate 4 inactive slots
	void ExpandInventory() //should probably scrap this
    {
		//Activate all
        for (int i = 0; i < 20; i++)
        {
			if (!slotList[i].activeSelf) slotList[i].SetActive(true);
        }
		//Deactivate
		int itemsInRow = 0;
		int cellsToCheck = 4;
		for (int i = 19; i > (19-cellsToCheck); i--)
        {
			if (itemList[i] != null) itemsInRow++; //counts items in row

			if ((i + 1) % 4 != 0) continue;

			if (itemsInRow > 0)
			{
				return;
			}
			else if (i != 19)
			{
				for (int j = (i+4); j > i; j--)
				{
					slotList[j].SetActive(false);
				}
			}
			itemsInRow = 0;
			cellsToCheck += 4;
			if (cellsToCheck > 19) return;
		}
	}
	public bool InventoryFull()
    {
        for (int i = 0; i < 20; i++)
        {
			if (itemList[i] == null) return false;
        }
		return true;
    }
}