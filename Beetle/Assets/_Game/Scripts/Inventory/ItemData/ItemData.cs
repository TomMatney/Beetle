using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public string Name;
    public string Description;
    public int StackSize = 1;
    public int Id;
    public Sprite Icon;
    public ItemAction[] Actions;
    public List<string> Tags;

    /// <summary>
    /// Searches through Actions for typeof(T). Can be null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T FindItemActionOfType<T>() where T: ItemAction
    {
        foreach (var action in Actions)
        {
            if (action is T)
            {
                return (T)action;
            }
        }
        return null;
    }

    public bool HasItemActionOfType<T>() where T: ItemAction
    {
        return FindItemActionOfType<T>() != null;
    }

    public bool IsEquippable()
    {
        return HasItemActionOfType<EquippableItemAction>();
    }

    public void EquipItem(PlayerData playerData)
    {
        var equipAction = FindItemActionOfType<EquippableItemAction>();
        if(equipAction)
        {
            equipAction.OnEquip(playerData);
        }
    }

    public void UnequipItem(PlayerData characterData)
    {
        var equipAction = FindItemActionOfType<EquippableItemAction>();
        if (equipAction)
        {
            equipAction.OnUnequip(characterData);
        }
    }
}
