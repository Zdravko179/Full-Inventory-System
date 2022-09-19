using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase_Y : MonoBehaviour
{
    public static ItemDatabase_Y Instance { get; private set; }


    private List<ItemZ> database = new List<ItemZ>();
    public Object[] itemDatas { get; private set; }


    private void Awake()
    {
        Instance = this;
        itemDatas = Resources.LoadAll("ItemsZ", typeof(ScriptableObject));
        ConstructItemDatabase();
        foreach (Object itemData in itemDatas)
        {
            if (itemData == null) Debug.LogWarning(itemData + " (scriptable object) is missing");
        }
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
