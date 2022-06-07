using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    //[SerializeField] private MeshFilter meshFilter;
    [SerializeField] private float scale = 1f;

    private Vector3 startPosition;

    void Start()
    {
        //var meshItem = Instantiate(itemData.Mesh, transform.position, transform.rotation, transform);
        //meshItem.transform.localScale *= scale;
        //TODO Make sprite
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(0f, 90f * Time.deltaTime, 0f, Space.World);
        transform.position = startPosition + (Vector3.up * Mathf.Cos(Time.time) * 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.GetComponent<PlayerInventory>();
        if (inventory != null)
        {
            var item = ItemManager.GetItemData(itemData.Id);
            inventory.AddItem(item);
            //if(item.IsEquippable())
            //{
            //    item.EquipItem(other.GetComponent<CharacterData>());
            //}
            //TODO particle effect
            DestroyItem();
        }
    }

    private void DestroyItem()
    {
        Destroy(gameObject);
        //if(IsServer)
        //{
        //    DestroyItemClientRPC();
        //}
        //else
        //{
        //    DestroyItemServerRPC();
        //}
    }

    //[ServerRpc(RequireOwnership = false)]
    //private void DestroyItemServerRPC()
    //{
    //    DestroyItemClientRPC();
    //}

    //[ClientRpc]
    //private void DestroyItemClientRPC()
    //{
    //    Destroy(gameObject);
    //}
}
