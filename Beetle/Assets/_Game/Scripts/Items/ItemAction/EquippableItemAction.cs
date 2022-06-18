using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquippableItemAction : ItemAction
{
    public abstract void OnEquip(PlayerData characterData);

    public abstract void OnUnequip(PlayerData characterData);
}
