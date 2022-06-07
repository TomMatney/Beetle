using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DamageDealer : MonoBehaviour
{
	public PlayerFeels pFeel;
    public LayerMask layerMask;
    public float damageAmount = 10f;

    private void OnTriggerEnter(Collider collision)
    {
        if (layerMask.IsInLayerMask(collision.gameObject.layer) == false)
        {
            return;
        }

        Health health = collision.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(transform.root.gameObject, damageAmount, transform.position, transform.forward);
            pFeel.Change();
        }
    }
}
