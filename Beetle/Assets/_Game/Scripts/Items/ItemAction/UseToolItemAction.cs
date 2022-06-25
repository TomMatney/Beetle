using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseToolItemAction : ItemAction
{
    public ResourceNodeType resourceNodeType;
    public ResourceTier resourceTier;
    public float damageAmount = 30f;

    public void OnUse(PlayerData characterData)
    {
        characterData.WeaponAnimator.Attack(OnHit);
    }

    public void OnHit(PlayerData characterData, Health health)
    {
        var node = health.GetComponent<Tree>();
        if (node != null)
        {
            if(node.resourceNodeType == resourceNodeType && resourceTier >= node.resourceTier)
            {
                health.Damage(characterData.gameObject, damageAmount, health.transform.position, health.transform.forward);
                return;
            }
            else
            {
                health.Damage(characterData.gameObject, 0f, health.transform.position, health.transform.forward);
            }
        }

        health.Damage(characterData.gameObject, damageAmount, health.transform.position, health.transform.forward);
    }
}
