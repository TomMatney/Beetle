using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DamageDealer : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Gatherable")
        {
            collision.gameObject.GetComponent<TreeFeedback>().Tree();
            collision.gameObject.GetComponent<PlayerFeels>().Change();
            
        }
    }
}
