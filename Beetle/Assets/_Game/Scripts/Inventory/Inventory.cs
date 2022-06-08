using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [SerializeField] private List<ItemInstance> items = new List<ItemInstance>();

    public List<ItemInstance> Items => items;

    public void AddItem(ItemData newItem, int count = 1)
    {
        bool added = false;
        foreach(var item in items)
        {
            if(item.Id == newItem.Id)
            {
                if(item.Amount + count <= newItem.StackSize)
                {
                    item.Amount += count;
                    added = true;
                    break;
                }
            }
        }
        if(!added)
        {
            ItemInstance itemInstance = new ItemInstance(newItem.Id, count);
            items.Add(itemInstance);
        }
    }

    public bool HasItem(ItemInstance item)
    {
        bool hasItem = false;
        foreach(ItemInstance it in items)
        {
            if (it.Id == item.Id)
                return true;
        }
        return hasItem;
    }

    public void RemoveItem(ItemInstance item)
    {

    }
}
