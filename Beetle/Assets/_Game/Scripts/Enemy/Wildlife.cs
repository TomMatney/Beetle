using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wildlife : MonoBehaviour
{
    //public MMFeedbacks treeFeels;
    public MMFeedbacks deathFeels;

    public ItemDropTable dropTable = new ItemDropTable();

    private void Start()
    {
        Health health = GetComponent<Health>();
        //health.damageTakenEvent.AddListener(DamageTree);
        health.deathEvent.AddListener(OnDeath);
    }

    //public void DamageTree(DamageData damageData)
    //{
    //    treeFeels?.PlayFeedbacks();
    //}

    private void OnDeath(DamageData damageData)
    {
        //deathFeels?.PlayFeedbacks();
        //GetComponent<Collider>().enabled = false;

        DestroyTree();
    }

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
}
