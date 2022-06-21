using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CraftingRecipe : ScriptableObject
{
    [System.Serializable]
    public class ItemCraftData : CraftData
    {
        public int ItemId => ItemData != null ? ItemData.Id : -1;
        [ItemDataPreview] [SerializeField] private ItemData ItemData;

        public override bool MatchesItem(int id)
        {
            return id == ItemId;
        }
    }

    [System.Serializable]
    public class TagCraftData : CraftData
    {
        public string tag;

        public override bool MatchesItem(int id)
        {
            return ItemManager.GetItemData(id).Tags.Contains(tag);
        }
    }

    public abstract class CraftData
    {
        public int Amount;
        public abstract bool MatchesItem(int id);
    }

    public List<ItemCraftData> itemInput;
    public List<TagCraftData> tagInput;
    //This could be a list to output multiple items
    public ItemCraftData output;

    public bool CanCraft(Inventory inventory)
    {
        List<CraftData> craftData = new List<CraftData>(itemInput.Count + tagInput.Count);
        craftData.AddRange(itemInput);
        craftData.AddRange(tagInput);

        //This would be a dramatic speedup if inventory.Items was a dictionary
        foreach (var item in inventory.Items)
        {
            if(craftData.Count > 0)
            {
                for (int i = 0; i < craftData.Count; i++)
                {
                    CraftData input = craftData[i];
                    if (input.MatchesItem(item.Id))
                    {
                        if(item.Amount >= input.Amount)
                        {
                            craftData.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
            else
            {
                //Went through all itemData
                break;
            }
        }

        return craftData.Count > 0;
    }
}
