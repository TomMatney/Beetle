using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseToolItemAction : ItemAction
{
    public ResourceNodeType resourceNodeType;
    public ResourceTier resourceTier;

    public void OnUse(PlayerData characterData)
    {
        characterData.WeaponAnimator.Attack();
        //TODO set WeaponHandler nodeType
    }
}
