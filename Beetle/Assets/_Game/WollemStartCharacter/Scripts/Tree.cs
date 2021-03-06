using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public MMFeedbacks treeFeels;
    public MMFeedbacks treeFall;

    public ItemDropTable dropTable = new ItemDropTable();

    public ResourceNodeType resourceNodeType;
    public ResourceTier resourceTier;

    private void Start()
    {
        Health health = GetComponent<Health>();
        health.damageTakenEvent.AddListener(DamageTree);
        health.deathEvent.AddListener(OnDeath);
    }

    public void DamageTree(DamageData damageData)
    {
        treeFeels?.PlayFeedbacks();
    }

    //Called from animationEvent
    protected void DestroyTree()
    {
        Destroy(gameObject);
        foreach (var drop in dropTable.dropData)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance <= drop.dropChance)
            {
                ItemManager.DropItem(drop.itemData, drop.amount.Random(), transform.position);
            }
        }
    }

    private void OnDeath(DamageData damageData)
    {
        treeFall?.PlayFeedbacks();
        GetComponent<Collider>().enabled = false;
    }
}
