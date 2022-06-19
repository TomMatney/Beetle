using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHotbar : MonoBehaviour
{
    [SerializeField] private ItemHotbarButton[] itemSlotsIcons;

    private PlayerInventory inventory;

    private KeyCode[] hotkeys = new KeyCode[] {
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6,
    KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9};

    private string[] hotkeyStrings = new string[] {
        "1", "2", "3", "4", "5", "6", "7", "8", "9"};

    private int selectedIndex = 0;

    [SerializeField] private RectTransform selectIcon;

    private void Start()
    {
        Initialize(FindObjectOfType<PlayerInventory>());
        SetHotbarSelection(0);
    }

    public void Initialize(PlayerInventory inventory)
    {
        this.inventory = inventory;

        inventory.Inventory.OnInventoryChanged += OnItemsChanged;

        //KeyCode[] hotkeys = inventory.Hotkeys;
        for (int i = 0; i < itemSlotsIcons.Length; i++)
        {
            ItemHotbarButton button = itemSlotsIcons[i];
            button.Initialize(hotkeyStrings[i] /*, Sprite defaultIcon*/);
        }

        OnItemsChanged();
    }

    private void Update()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel > 0f)
        {
            SetHotbarSelection(++selectedIndex);
        }
        else if(scrollWheel < 0f)
        {
            SetHotbarSelection(--selectedIndex);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            UseItemAtIndex(selectedIndex);
        }

        for (int i = 0; i < hotkeys.Length; i++)
        {
            if(Input.GetKeyDown(hotkeys[i]))
            {
                if(inventory.Inventory.Items.Count > i)
                {
                    UseItemAtIndex(i);
                }
            }
        }
    }

    private void SetHotbarSelection(int newSelection)
    {
        if(newSelection < 0)
        {
            newSelection = itemSlotsIcons.Length - 1;
        }
        if(newSelection >= itemSlotsIcons.Length)
        {
            newSelection = 0;
        }
        selectedIndex = newSelection;
        selectIcon.position = itemSlotsIcons[newSelection].GetComponent<RectTransform>().position;
    }

    private void UseItemAtIndex(int index)
    {
        if (inventory.Inventory.Items.Count > index)
        {
            var item = inventory.Inventory.Items[index];
            var itemData = ItemManager.GetItemData(item.Id);
            if (itemData != null)
            {
                var useToolAction = itemData.GetItemActionOfType<UseToolItemAction>();
                if (useToolAction != null)
                {
                    useToolAction.OnUse(inventory.PlayerData);
                }
            }
        }
    }

    public void OnItemsChanged()
    {
        var items = inventory.Inventory.Items;
        for (int i = 0; i < itemSlotsIcons.Length; i++)
        {
            if(i >= items.Count)
            {        
                itemSlotsIcons[i].Clear();
                continue;
            }

            var item = inventory.Inventory.Items[i];
            if (item != null)
            {
                itemSlotsIcons[i].SetItem(item, ItemManager.GetItemData(item.Id));
            }
        }
        //if (newAbility != null)
        //{
        //    abilitySlotsIcons[slot].SetAbility(newAbility, newAbility.abilityData);
        //    //TODO Is this a bug adding mutliple listeners?
        //    newAbility.OnCooldownChanged.AddListener(abilitySlotsIcons[slot].SetCooldown);
        //}
        //else
        //{
        //    //TODO clear button and set default
        //}
    }
}
