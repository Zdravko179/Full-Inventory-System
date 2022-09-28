using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    Inventory inventory;
    public bool PickUpByClick = false;

    public void SetInventory(Inventory inventory) => this.inventory = inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) SwitchPickUpModes();
        if (PickUpByClick) GetItemOnClick();
    }

    private void SwitchPickUpModes()
    {
        PickUpByClick = PickUpByClick ? false : true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!PickUpByClick) GetItemOnCollision(collision);
    }
    void GetItemOnCollision(Collider2D collision)
    {
        if (collision.GetComponent<ItemWorld>() != null)
        {
            AddItemWorld(collision);
        }
    }
    void GetItemOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, -Vector2.up);
            if (hit.collider.GetComponent<ItemWorld>() != null)
            {
                AddItemWorld(hit.collider);
            }
        }
    }
    void AddItemWorld(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        if (itemWorld.canBeTaken) inventory.AddItemById(itemWorld.id, itemWorld.ammount, itemWorld);
        itemWorld.DelayCanBeTaken();
    }
}
