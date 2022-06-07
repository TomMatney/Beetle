using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : Enemy
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float retreatDistanceMax = 5;
    [SerializeField] private float retreatDistanceMin = 7;
    [SerializeField] private float turnSpeedDegrees = 100f;
    [SerializeField] private float attackDamage = 10f;

    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private Rigidbody rb;

    private State currentState;
    private Vector3 retreatPosition;
    private Vector3 targetPosition;

    private enum State
    {
        Attacking, Retreating
    }

    protected override void HandleIdle()
    {
        base.HandleIdle();
        animator.SetFloat("MoveSpeed", 0f);
    }

    protected override void HandleCombat()
    {
        animator.SetFloat("MoveSpeed", 1f);
        switch (currentState)
        {
            case State.Attacking:
                HandleStateAttacking();
                break;
            case State.Retreating:
                HandleStateRetreating();
                break;
            default:
                Debug.LogError($"No case for {currentState}");
                break;
        }
    }

    private void HandleStateRetreating()
    {
        MoveTowardsPosition(retreatPosition);

        if (Vector3.Distance(transform.position, retreatPosition) < 0.75f)
        {
            FindTarget();
            SetState(State.Attacking);
        }
    }

    private void HandleStateAttacking()
    {
        MoveTowardsPosition(target.GetCenterPosition());

        if (Vector3.Distance(transform.position, target.GetCenterPosition()) < 0.9f)
        {
            DamagePlayer();
        }
    }

    private void MoveTowardsPosition(Vector3 position)
    {
        targetPosition = position;
        Vector3 direction = (position - transform.position).normalized;
        //transform.position += transform.forward * moveSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), turnSpeedDegrees * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            //transform.position += direction * moveSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + (transform.forward * moveSpeed * Time.fixedDeltaTime));
            rb.velocity = Vector3.zero;
        }
    }

    protected override void OnDamageTaken(DamageData damageData)
    {
        animator.SetTrigger("Hurt");
        SetState(State.Retreating);
    }

    protected override void OnDeath(DamageData damageData)
    {
        animator.SetTrigger("Die");
        audioSource.clip = deathSound;
        audioSource.Play();
        audioSource.transform.parent = null;
        Destroy(audioSource.gameObject, deathSound.length);
        Destroy(gameObject);
        //TODO Let room manager know
    }

    private void DamagePlayer()
    {
        target.CharacterHealth.health.Damage(gameObject, attackDamage, transform.position, transform.forward);
        animator.SetTrigger("Attack");
        SetState(State.Retreating);
    }

    private void SetState(State newState)
    {
        currentState = newState;
        switch (newState)
        {
            case State.Attacking:
                break;
            case State.Retreating:
                FindRetreatPosition();
                break;
            default:
                break;
        }
    }

    private void FindRetreatPosition()
    {
        Vector3 offset = (UnityEngine.Random.onUnitSphere * Random.Range(retreatDistanceMin, retreatDistanceMax));
        offset.y = Mathf.Abs(offset.y);
        retreatPosition = transform.position + offset;
    }
}
