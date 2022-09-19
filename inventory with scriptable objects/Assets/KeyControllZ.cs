using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControllZ : MonoBehaviour
{
    public GameObject inventory, equipment, stats;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) Activation(inventory);
        if (Input.GetKeyDown(KeyCode.O)) Activation(equipment);
        if (Input.GetKeyDown(KeyCode.P)) Activation(stats);
    }
    void Activation(GameObject obj)
    {
        obj.SetActive(obj.activeSelf ? false : true);
    }
}
