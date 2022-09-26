using System;
using UnityEngine;
using UnityEngine.UI;

public class EquipUI : MonoBehaviour
{
    public Transform equipPanel;
    private Equipment equipment;
    private Image[] placeholderImages = new Image[4];

    
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            placeholderImages[i] = equipPanel.GetChild(i).GetChild(0).GetComponent<Image>();
            equipPanel.GetChild(i).GetComponent<EquipSlotUI>().equipment = equipment;
        }
        
    }
    public void SetEquipment(Equipment equipment)
    {
        this.equipment = equipment;
        equipment.OnItemListChanged += OnItemListChanged;
        RefreshEquipment();
    }    

    private void OnItemListChanged(object sender, EventArgs e) => RefreshEquipment();
    public void OnEnableRefresh()
    {
        if (DraggedItem.dragging)
        {
            RefreshEquipment();
            DraggedItem.Instance.Deactivate();
            Tooltip.Instance.Deactivate();
            DraggedItem.dragging = false;
        }
    }

    void RefreshEquipment()
    {
        //set all slots sprites to placeholders
        for (int i = 0; i < 4; i++)
        {
            equipPanel.GetChild(i).GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, 0.2f);
            equipPanel.GetChild(i).GetComponent<SlotUI>().item = null;
        }

        //set new sprites
        
        int index = 0;
        if (equipment.head != null) 
        { 
            equipPanel.GetChild(index).GetChild(0).GetComponent<Image>().sprite = equipment.head.data.sprite; 
            equipPanel.GetChild(index).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            equipPanel.GetChild(index).GetComponent<SlotUI>().item = equipment.head;
        }
        index++;
        if (equipment.body != null) 
        { 
            equipPanel.GetChild(index).GetChild(0).GetComponent<Image>().sprite = equipment.body.data.sprite; 
            equipPanel.GetChild(index).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            equipPanel.GetChild(index).GetComponent<SlotUI>().item = equipment.body;
        }
        index++;
        if (equipment.hands != null) 
        { 
            equipPanel.GetChild(index).GetChild(0).GetComponent<Image>().sprite = equipment.hands.data.sprite; 
            equipPanel.GetChild(index).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            equipPanel.GetChild(index).GetComponent<SlotUI>().item = equipment.hands;
        }
        index++;
        if (equipment.accesory != null) 
        { 
            equipPanel.GetChild(index).GetChild(0).GetComponent<Image>().sprite = equipment.accesory.data.sprite; 
            equipPanel.GetChild(index).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            equipPanel.GetChild(index).GetComponent<SlotUI>().item = equipment.accesory;
        }
    }
}
