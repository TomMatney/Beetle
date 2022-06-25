using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private ItemDatabase itemDatabase;
    [SerializeField] private ItemObject itemPrefab;

    private static ItemManager instance;

    private Dictionary<int, ItemData> ItemMap = new Dictionary<int, ItemData>();

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError($"Instance of {typeof(ItemManager)} already exists");
            this.enabled = false;
        }
        else
        {
            instance = this;
            if(itemDatabase == null)
            {
                Debug.LogError("No ItemDatabase", this);
                return;
            }

            foreach(var itemData in itemDatabase.Items)
            {
                if(ItemMap.ContainsKey(itemData.Id))
                {
                    Debug.LogError($"ItemId: {itemData.Id} named {itemData.Name} already in use by {ItemMap[itemData.Id].Name}");
                }
                else
                {
                    ItemMap.Add(itemData.Id, itemData);
                }
            }
        }
    }

    public static void DropItem(ItemData itemData, int amount, Vector3 position)
    {
        var itemObject = Instantiate(instance.itemPrefab, position, instance.itemPrefab.transform.rotation);
        itemObject.SetItemData(itemData, amount);
    }

    public static ItemData GetItemData(int itemId)
    {
        if(instance.ItemMap.TryGetValue(itemId, out var itemData))
        {
            return itemData;
        }
        Debug.LogError($"No Id: {itemId} found in {instance.itemDatabase.name}");
        return null;
    }
}
