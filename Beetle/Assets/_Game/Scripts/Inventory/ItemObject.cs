using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private int amount;
    private ItemData itemData;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float scale = 1f;

    public void SetItemData(ItemData itemData, int amount)
    {
        this.itemData = itemData;
        this.amount = amount;
        spriteRenderer.sprite = itemData.Icon;
    }

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.GetComponent<PlayerInventory>();
        if (inventory != null)
        {
            inventory.AddItem(itemData, amount);
            DestroyItem();
        }
    }

    private void DestroyItem()
    {
        Destroy(gameObject);
    }
}
