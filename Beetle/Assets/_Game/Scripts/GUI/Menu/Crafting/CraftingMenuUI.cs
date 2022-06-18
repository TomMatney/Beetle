using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenuUI : MonoBehaviour
{
    [SerializeField] private CraftingMenuButton craftingButtonPrefab;

    [SerializeField] private CraftingRecipe[] recipes;

    [SerializeField] private RectTransform holder;

    void Start()
    {
        for(int i = 0; i < recipes.Length; i++)
        {
            var button = Instantiate(craftingButtonPrefab, holder);
            button.Initialize(recipes[i]);
        }
    }
}
