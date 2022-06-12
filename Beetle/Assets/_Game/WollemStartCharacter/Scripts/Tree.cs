using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public MMFeedbacks treeFeels;
    public MMFeedbacks treeFall;
    public ItemObject itemPrefab;

    public ItemDropTable dropTable = new ItemDropTable();

    private void Start()
    {
        Health health = GetComponent<Health>();
        health.damageTakenEvent.AddListener(DamageTree);
        health.deathEvent.AddListener(DestroyTree);
    }
    public void DamageTree(DamageData damageData)
    {
        treeFeels?.PlayFeedbacks();
    }

    protected virtual void GetRidOf()
    {
        Destroy(gameObject);
        Instantiate(itemPrefab, transform.position, itemPrefab.transform.rotation);
        Debug.Log("Deleted");
    }
    private void DestroyTree(DamageData damageData)
    {
        //var inventory = damageData.source?.GetComponent<PlayerData>()?.PlayerInventory;
        //if (inventory != null)
        //{
        //    inventory.AddItem(dropTable);
        //}

        //Instantiate(itemPrefab, transform.position, itemPrefab.transform.rotation);
        // Destroy(gameObject);

        treeFall?.PlayFeedbacks();
    }
}
