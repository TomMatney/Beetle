using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Vector3 velocity;
    protected Vector3 acceleration;
    //private float speed;
    protected float damage;
    protected LayerMask hitLayer;

    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected ParticleSystem hitParticle;

    [SerializeField] protected AudioClip flySound;
    [SerializeField] protected AudioClip hitSound;
    [SerializeField] protected AudioSource audioSource;

    protected virtual void FixedUpdate()
    {
        velocity += acceleration * Time.deltaTime;
        rb.velocity = velocity;
        //rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }

    public virtual void Initialize(Vector3 velocity, Vector3 acceleration, float projectileDamage, LayerMask hitLayer)
    {
        this.velocity = velocity;
        this.acceleration = acceleration;
        //this.speed = projectileSpeed;
        this.damage = projectileDamage;
        this.hitLayer = hitLayer;

        audioSource.clip = flySound;
        audioSource.loop = true;
        audioSource.Play();
        Destroy(this.gameObject, 20f);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if(hitLayer == (hitLayer | (1 << collision.gameObject.layer)))
        {
            Hit(collision.gameObject, collision.GetContact(0).point, velocity);
        }
    }

    protected virtual void Hit(GameObject target, Vector3 point, Vector3 direction)
    {
        var health = target.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(gameObject, damage, point, direction);
        }
        if(hitParticle)
        {
            Instantiate(hitParticle, point, Quaternion.identity);
        }
        Cleanup();
    }

    protected virtual void Cleanup()
    {
        audioSource.clip = hitSound;
        audioSource.loop = false;
        audioSource.Play();
        audioSource.transform.parent = null;
        Destroy(audioSource.gameObject, hitSound.length);
        Destroy(gameObject);
    }
}
