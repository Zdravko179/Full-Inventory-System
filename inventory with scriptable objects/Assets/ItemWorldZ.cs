using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldZ : MonoBehaviour
{
    public ItemZ item;
    public int amount;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item.sprite;
        if (amount > item.stackLimit) amount = item.stackLimit;
    }
}
