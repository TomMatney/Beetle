using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory Inventory = new Inventory();
    public PlayerData PlayerData;

    public void AddItem(ItemData itemData, int count = 1)
    {
        ItemGainedPreviewPanel.AddItem(itemData, count);
        Inventory.AddItem(itemData, count);
    }

    public void AddItem(ItemDropTable dropTable)
    {
        foreach(var drop in dropTable.dropData)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance <= drop.dropChance)
            {
                AddItem(drop.itemData, drop.amount.Random());
            }
        }
    }
}
