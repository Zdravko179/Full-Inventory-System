using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject inventory, equipment, stats;

    public void _Activation(GameObject obj)
    {
        obj.SetActive(obj.activeSelf ? false : true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(inventory.activeSelf ? false : true);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            equipment.SetActive(equipment.activeSelf ? false : true);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            stats.SetActive(stats.activeSelf ? false : true);
        }
    }
}
