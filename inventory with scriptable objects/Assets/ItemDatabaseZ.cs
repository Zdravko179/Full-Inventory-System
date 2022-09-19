using System.Collections.Generic;
using UnityEngine;

public class ItemDatabaseZ : MonoBehaviour
{
    public static ItemDatabaseZ Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private List<ItemZ> database = new List<ItemZ>();
    public Object[] itemDatas { get; private set; }

    private void Start()
    {
        itemDatas = Resources.LoadAll("ItemsZ", typeof(ScriptableObject));
        ConstructItemDatabase();
        Debug.Log("database costructed: " + database.Count);
    }
    public ItemZ FetchItemById(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].id == id)
            {
                return database[i];
            }
        }
        return null;
    }
    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemDatas.Length; i++)
        {
            ItemZ newItem = (ItemZ)itemDatas[i];
            newItem.id = i;
            database.Add(newItem);
        }
    }
}
