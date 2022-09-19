using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZ : MonoBehaviour
{
    InventoryZ inv;

    private void Start()
    {
        inv = FindObjectOfType<InventoryZ>();
    }
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ItemWorldZ>() != null)
        {
            if (inv.InventoryFull())
            {
                Debug.Log("Invetory full");
                return;
            }
            int id = collision.GetComponent<ItemWorldZ>().item.id;
            int amount = collision.GetComponent<ItemWorldZ>().amount;
            inv.AddItem(id, amount);
            Destroy(collision.gameObject);
        }
    }
}
