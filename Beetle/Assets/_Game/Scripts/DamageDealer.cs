using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DamageDealer : MonoBehaviour
{
    public PlayerFeels pFeel;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Gatherable")
        {
            collision.gameObject.GetComponent<TreeFeedback>().Tree();
            pFeel.Change();
            
        }
    }
}
