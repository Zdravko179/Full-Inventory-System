using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
	public static Tooltip Instance;

	private Item item;
	private string data;
	private GameObject tooltip;

    private void Awake()
    {
		Instance = this;
    }
    void Start()
	{
		tooltip = GameObject.Find("Tooltip UI");
		tooltip.SetActive(false);
	}

	void Update()
	{
		if (tooltip.activeSelf)
		{
			tooltip.transform.position = Input.mousePosition;
		}
	}

	public void Activate(Item item)
	{
		this.item = item;
		ConstructDataString();
		tooltip.SetActive(true);
	}

	public void Deactivate()
	{
		tooltip.SetActive(false);
	}

	public void ConstructDataString()
	{
		if (item.data.itemType == GlobalClass.ItemType.Helmet || item.data.itemType == GlobalClass.ItemType.BodyArmour || item.data.itemType == GlobalClass.ItemType.Gauntlet || item.data.itemType == GlobalClass.ItemType.Accesory)
        {
			data = "<color=#FFEC58FF><b>" + item.data.name + "</b></color>\n\n" + item.data.description
				+ "\nPower: " + item.data.power
				+ "\nDefense: " + item.data.defense
				+ "\nAgility: " + item.data.agility
				+ "\nLuck: " + item.data.luck;
        }
        else
        {
			data = "<color=#FFEC58FF><b>" + item.data.name + "</b></color>\n\n" + item.data.description;
		}
		tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
	}
}
