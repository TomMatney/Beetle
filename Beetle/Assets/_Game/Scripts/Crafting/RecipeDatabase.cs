using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeDatabase", menuName = "Beetle/RecipeDatabase", order = 1)]

public class RecipeDatabase : ScriptableObject
{
    public List<CraftingRecipe> Recipes;
}
