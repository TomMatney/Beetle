using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMageEnemy : Enemy
{
    private enum State
    {
        Attacking, Moving
    }

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float attackDistance = 5;
    [SerializeField] private float turnSpeedDegrees = 100f;
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private Transform shootPoint = default;
    [SerializeField] private Projectile projectile = default;
    [SerializeField] private LayerMask hitLayer = default;
    [SerializeField] private float projectileDamage = 5f;
    [SerializeField] private float attackCooldown = 4f;

    [SerializeField] private State currentState = State.Moving;

    private float attackTimer = 4f;
    private string moveSpeedAnimKey = "MoveSpeed";

    protected override void HandleCombat()
    {
        switch (currentState)
        {
            case State.Attacking:
                HandleStateAttacking();
                break;
            case State.Moving:
                HandleStateMoving();
                break;
            default:
                Debug.LogError($"No case for {currentState}");
                break;
        }
    }

    protected override void HandleIdle()
    {
        animator.SetFloat(moveSpeedAnimKey, 0f);
        base.HandleIdle();
    }

    private void HandleStateMoving()
    {
        Vector3 targetPosition = target.GetCenterPosition();
        MoveTowardsPosition(target.transform.position);

        if (Vector3.Distance(transform.position, targetPosition) < attackDistance)
        {
            FindTarget();
            SetState(State.Attacking);
        }
    }

    private void HandleStateAttacking()
    {
        Vector3 targetPosition = target.GetCenterPosition();
        if(Vector3.Distance(targetPosition, transform.position) > attackDistance)
        {
            SetState(State.Moving);
            return;
        }

        attackTimer -= Time.deltaTime;

        Vector3 lookDirection = (target.transform.position - transform.position).normalized;
        if(Vector3.Dot(lookDirection, transform.forward) < .9f)
        {
            float moveSpeedAnim = animator.GetFloat(moveSpeedAnimKey);
            moveSpeedAnim = Mathf.MoveTowards(moveSpeedAnim, 1f, Time.deltaTime * 2f);
            animator.SetFloat(moveSpeedAnimKey, 1f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookDirection), turnSpeedDegrees * Time.deltaTime);
        }
        else
        {
            float moveSpeedAnim = animator.GetFloat(moveSpeedAnimKey);
            float newMoveSpeedAnim = Mathf.MoveTowards(moveSpeedAnim, 0f, Time.deltaTime * 2f);
            animator.SetFloat(moveSpeedAnimKey, newMoveSpeedAnim);
            if (attackTimer <= 0f)
            {
                Vector3 shootDir = (targetPosition - shootPoint.position).normalized;
                ShootProjectile(projectile, shootPoint.position + shootDir*0.4f, shootDir, projectileSpeed, projectileDamage, hitLayer);
                attackTimer = attackCooldown;
                animator.SetTrigger("Attack");
            }
        }
    }

    private void OnDamaged()
    {
        animator.SetTrigger("Hurt");
        //TODO interupt attack?
    }

    private void OnDeath()
    {
        Destroy(gameObject);
        //TODO Let room manager know
    }

    private void MoveTowardsPosition(Vector3 position)
    {
        Vector3 direction = (position - transform.position).normalized;
        direction.y = 0f;
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), turnSpeedDegrees * 2f * Time.deltaTime);
        animator.SetFloat(moveSpeedAnimKey, 1f);
    }

    private void SetState(State newState)
    {
        currentState = newState;
        switch (newState)
        {
            case State.Attacking:
                //attackCooldown = attackTimer;
                break;
            case State.Moving:
                break;
            default:
                break;
        }
    }
}
