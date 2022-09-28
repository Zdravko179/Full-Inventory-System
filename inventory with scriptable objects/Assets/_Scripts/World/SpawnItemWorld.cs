using UnityEngine;

public class SpawnItemWorld : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float minRadius, maxRadius;
    [SerializeField] private GameObject itemWorld;

    public static SpawnItemWorld Instance;


    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int ammount = 3;
            for (int i = 0; i < ammount; i++)
            {
                ItemWorld newItem = SpanwNewItem();
                newItem.id = Random.Range(0, ItemDatabase.Instance.itemDatas.Length);
                newItem.ammount = Random.Range(1, 11);
            }
        }
    }

    public void DropItem(Item item)
    {
        ItemWorld newItem = SpanwNewItem();
        newItem.id = item.data.id;
        newItem.ammount = item.ammount;
    }

    ItemWorld SpanwNewItem()
    {
        ItemWorld newItem = Instantiate(itemWorld, RandomDropLocation(), Quaternion.identity).GetComponent<ItemWorld>();
        return newItem;
    }
    Vector3 RandomDropLocation()
    {
        int angle = Random.Range(0, 360);
        Vector3 newPos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * Random.Range(minRadius, maxRadius) + target.transform.position;
        return newPos;
    }
}