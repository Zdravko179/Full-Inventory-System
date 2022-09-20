using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemWorld : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float radius;
    [SerializeField] private GameObject itemWorld;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int angle = Random.Range(0, 360);
            Vector3 newPos = new Vector3(Mathf.Cos(Random.Range(0, 360)) * radius, Mathf.Sin(Random.Range(0, 360)) * radius) + target.transform.position;
            ItemWorld item = Instantiate(itemWorld, newPos, Quaternion.identity).GetComponent<ItemWorld>(); //{ item.id = 1; item.ammount = 1; }
            item.id = Random.Range(0, ItemDatabase.Instance.itemDatas.Length);
            item.ammount = Random.Range(0, 10);
        }
    }
}