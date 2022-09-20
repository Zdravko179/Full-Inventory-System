using System;
using UnityEngine;
using UnityEngine.UI;

public class EquipUI : MonoBehaviour
{
    public Transform equipPanel;
    private Equipment equipment;
    private Sprite[] itemImages;
    private Sprite[] placeholderImages;

    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            itemImages[i] = equipPanel.GetChild(i).GetComponent<Sprite>();
            placeholderImages[i] = equipPanel.GetChild(i).GetComponent<Sprite>();
            transform.GetChild(0).GetComponent<EquipSlotUI>().equipment = equipment;
        }
    }
    public void SetEquipment(Equipment equipment) => this.equipment = equipment;

    private void OnItemListChanged(object sender, EventArgs e) => RefreshEquipment();

    void RefreshEquipment()
    {
        //set all slots sprites to placeholders
        itemImages[0] = placeholderImages[0];
        itemImages[1] = placeholderImages[1];
        itemImages[2] = placeholderImages[2];
        itemImages[3] = placeholderImages[3];


        //set new sprites
        if (equipment.head != null) itemImages[0] = equipment.head.data.sprite;
        if (equipment.body != null) itemImages[1] = equipment.body.data.sprite;
        if (equipment.hands != null) itemImages[2] = equipment.hands.data.sprite;
        if (equipment.accesory != null) itemImages[3] = equipment.accesory.data.sprite;
    }
}
