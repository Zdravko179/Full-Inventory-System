using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_Y : MonoBehaviour
{
    public void _Activation(GameObject obj)
    {
        obj.SetActive(obj.activeSelf ? false : true);
    }
   
}
