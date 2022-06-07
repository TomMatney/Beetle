using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryListUI : MonoBehaviour
{
    [SerializeField] private InventoryListItemUI listItemPrefab;
    [SerializeField] private RectTransform itemHolder;

    private Inventory inventory;

    private List<InventoryListItemUI> listItems = new List<InventoryListItemUI>();

    private void OnEnable()
    {
        OpenWindow();
    }

    public void OpenWindow()
    {
        if(inventory == null)
        {
            PlayerData character = PlayerManager.GetLocalPlayer();
            if(character)
            {
                inventory = character.PlayerInventory.Inventory;
            }
        }

        //TODO only refresh if inventory has changed
        ClearItemList();
        PopulateItems();
    }

    public void CloseWindow()
    {

    }

    public void PopulateItems()
    {
        print(inventory.Items.Count);
        foreach(var item in inventory.Items)
        {
            ItemData itemData = ItemManager.GetItemData(item.Id);
            var newItem = Instantiate(listItemPrefab, itemHolder);
            newItem.SetItem(itemData);
            listItems.Add(newItem);
        }
    }

    private void ClearItemList()
    {
        foreach(var item in listItems)
        {
            Destroy(item.gameObject);
        }
        listItems.Clear();
    }
}
