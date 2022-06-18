using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CraftingMenuButton : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image OutputIcon;
    [SerializeField] private TMPro.TextMeshProUGUI OutputAmount;
    [SerializeField] private UnityEngine.UI.Image[] InputIcons;
    [SerializeField] private TMPro.TextMeshProUGUI[] InputAmounts;

    public void Initialize(CraftingRecipe craftingRecipe)
    {
        var outputItem = ItemManager.GetItemData(craftingRecipe.output.ItemId);
        OutputIcon.sprite = outputItem.Icon;
        OutputAmount.text = craftingRecipe.output.Amount.ToString();

        Assert.IsTrue(craftingRecipe.itemInput.Count <= 3);

        for (int i = 0; i < craftingRecipe.itemInput.Count; i++)
        {
            CraftingRecipe.ItemCraftData inputItem = craftingRecipe.itemInput[i];
            var itemData = ItemManager.GetItemData(inputItem.ItemId);
            InputIcons[i].sprite = itemData.Icon;
            InputAmounts[i].transform.parent.gameObject.SetActive(true);
            InputAmounts[i].text = inputItem.Amount.ToString();
        }

        for(int i = craftingRecipe.itemInput.Count; i < 3; i++)
        {
            InputAmounts[i].transform.parent.gameObject.SetActive(false);
        }
    }
}
