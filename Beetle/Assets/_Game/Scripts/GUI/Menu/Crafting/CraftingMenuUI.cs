using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenuUI : MonoBehaviour
{
    [SerializeField] private CraftingMenuButton craftingButtonPrefab;

    [SerializeField] private RecipeDatabase recipes;

    [SerializeField] private RectTransform holder;

    void Start()
    {
        for(int i = 0; i < recipes.Recipes.Count; i++)
        {
            var button = Instantiate(craftingButtonPrefab, holder);
            button.Initialize(recipes.Recipes[i], this);
        }
    }

    public void TryCraftItem(CraftingRecipe craftingRecipe)
    {
        var inventory = FindObjectOfType<PlayerInventory>();
        bool canCraft = true;
        List<ItemInstance> items = new List<ItemInstance>();
        foreach(var input in craftingRecipe.itemInput)
        {
            var item = inventory.Inventory.FindItem(input.ItemId, input.Amount);
            if(item != null)
            {
                items.Add(item);
            }
            else
            {
                canCraft = false;
                break;
            }
        }
        if(canCraft)
        {
            for (int i = 0; i < craftingRecipe.itemInput.Count; i++)
            {
                CraftingRecipe.ItemCraftData input = craftingRecipe.itemInput[i];
                items[i].Amount -= input.Amount;
                if(items[i].Amount == 0)
                {
                    inventory.Inventory.RemoveItem(items[i]);
                }
            }
            inventory.Inventory.AddItem(craftingRecipe.output.ItemId, craftingRecipe.output.Amount);
        }
    }
}
