using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public int id;
    public int ammount;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = ItemDatabase.Instance.FetchItemById(id).sprite;
        //if (ammount > item.soItem.stackLimit) ammount = item.soItem.stackLimit;
    }
    public ItemWorld()
    {

    }
}
