using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float targetRange = 15f;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Health health;

    protected PlayerData target;

    private void OnEnable()
    {
        if(health != null)
        {
            health.damageTakenEvent.AddListener(OnDamageTaken);
            health.deathEvent.AddListener(OnDeath);
        }
    }

    private void OnDisable()
    {
        if (health != null)
        {
            health.damageTakenEvent.RemoveListener(OnDamageTaken);
            health.deathEvent.RemoveListener(OnDeath);
        }
    }

    private void Update() { UpdateEnemy();  }

    protected void UpdateEnemy()
    {
        if (target == null)
        {
            HandleIdle();
        }
        else
        {
            if (TargetInRange())
            {
                Debug.DrawLine(transform.position, target.GetCenterPosition(), Color.green);

                HandleCombat();
            }
            else
            {
                target = null;
            }
        }
    }

    protected virtual void HandleIdle()
    {
        FindTarget();
    }

    protected abstract void HandleCombat();

    protected virtual void FindTarget()
    {
        var players = new List<PlayerData>(PlayerManager.GetPlayers());
        for (int i = 0; i < players.Count; i++)
        {
            PlayerData player = players[i];
            if (Vector3.Distance(player.GetCenterPosition(), transform.position) > targetRange)
            {
                players.Remove(player);
                i--;
            }
        }
        if (players.Count > 0)
        {
            int targetIndex = Random.Range(0, players.Count - 1);
            target = players[targetIndex];
        }
    }

    protected bool TargetInRange()
    {
        return Vector3.Distance(target.GetCenterPosition(), transform.position) < targetRange;
    }

    protected virtual void OnDamageTaken(DamageData damageData) { }

    protected virtual void OnDeath(DamageData damageData)
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetRange);
    }

    private void OnValidate()
    {
        if(health == null)
        {
            health = GetComponent<Health>();
        }
    }

    protected void ShootProjectile(Projectile projectile, Vector3 shootPoint, Vector3 direction,
        float projectileSpeed, float projectileDamage, LayerMask hitLayer)
    {
        Projectile newProj = Instantiate(projectile, shootPoint, Quaternion.LookRotation(direction));
        newProj.Initialize(direction * projectileSpeed, Vector3.zero, projectileDamage, hitLayer);
        var projCollider = newProj.GetComponent<Collider>();
        var myCollider = GetComponent<Collider>();
        if(projCollider && myCollider)
        {
            Physics.IgnoreCollision(projCollider, myCollider);
        }
    }
}
