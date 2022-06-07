using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHotbar : MonoBehaviour
{
    [SerializeField] private ItemHotbarButton[] abilitySlotsIcons = new ItemHotbarButton[4];

    private PlayerInventory inventory;

    public void Initialize(PlayerInventory inventory)
    {
        this.inventory = inventory;
        //inventory.OnItemsChanged += OnItemsChanged;

        //KeyCode[] hotkeys = inventory.Hotkeys;
        //for (int i = 0; i < abilitySlotsIcons.Length; i++)
        //{
        //    ItemHotbarButton button = abilitySlotsIcons[i];
        //    button.Initialize(hotkeys[i].ToString() /*, Sprite defaultIcon*/);
        //}
    }

    public void OnItemsChanged()
    {
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
