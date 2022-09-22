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
        if (ammount > ItemDatabase.Instance.FetchItemById(id).stackLimit) ammount = ItemDatabase.Instance.FetchItemById(id).stackLimit;
    }
    public ItemWorld()
    {

    }
}
