using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TooltipZ : MonoBehaviour
{
	private ItemZ item;
	private string data;
	private GameObject tooltip;

	void Start()
	{
		tooltip = GameObject.Find("TooltipZ");
		tooltip.SetActive(false);
	}

	void Update()
	{
		if (tooltip.activeSelf)
		{
			tooltip.transform.position = Input.mousePosition;
		}
	}

	public void Activate(ItemZ item)
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
		data = "<color=#FFEC58FF><b>" + item.name + "</b></color>\n\n" + item.description
			+ "\nPower: " + item.damageAmount;
		tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
	}

}
