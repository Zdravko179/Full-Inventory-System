using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance { get; private set; }


    private List<ItemData> database = new List<ItemData>();
    public Object[] itemDatas { get; private set; }


    private void Awake()
    {
        Instance = this;
        itemDatas = Resources.LoadAll("Items", typeof(ScriptableObject));
        ConstructItemDatabase();
        foreach (Object itemData in itemDatas)
        {
            if (itemData == null) Debug.LogWarning(itemData + " (scriptable object) is missing");
        }
    }

    public ItemData FetchItemById(int id)
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
            ItemData newItem = (ItemData)itemDatas[i];
            newItem.id = i;
            database.Add(newItem);
        }
    }
}
