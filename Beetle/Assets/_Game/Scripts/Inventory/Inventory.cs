using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [SerializeField] private List<ItemInstance> items = new List<ItemInstance>();

    public List<ItemInstance> Items => items;

    public System.Action OnInventoryChanged;

    public void AddItem(int itemId, int amount = 1)
    {
        var itemData = ItemManager.GetItemData(itemId);
        AddItem(itemData, amount);
    }

    public void AddItem(ItemData newItem, int amount = 1)
    {
        bool added = false;
        foreach(var item in items)
        {
            if(item.Id == newItem.Id)
            {
                if(item.Amount + amount <= newItem.StackSize)
                {
                    item.Amount += amount;
                    added = true;
                    break;
                }
            }
        }
        if(!added)
        {
            ItemInstance itemInstance = new ItemInstance(newItem.Id, amount);
            items.Add(itemInstance);
        }
        OnInventoryChanged.Invoke();
    }

    public bool HasItem(int itemId, int amount = 1)
    {
        return FindItem(itemId, amount) != null;
    }

    /// <summary>
    /// Use FindItem to find ItemInstance and then remove using this. 
    /// </summary>
    /// <param name="itemInstance"></param>
    public void RemoveItem(ItemInstance itemInstance)
    {
        items.Remove(itemInstance);
        OnInventoryChanged.Invoke();
    }

    public ItemInstance FindItem(int itemId, int amount = 1)
    {
        foreach (ItemInstance it in items)
        {
            if (it.Id == itemId && it.Amount >= amount)
                return it;
        }
        return null;
    }
}
