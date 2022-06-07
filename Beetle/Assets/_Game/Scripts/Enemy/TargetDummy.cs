using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    [SerializeField] private float downRotationX = -90f;
    [SerializeField] private float upRotationX = 0f;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private Health health;

    IEnumerator Start()
    {
        while(true)
        {
            FlipUp();
            yield return new WaitForSeconds(3f);
            FlipDown();
            yield return new WaitForSeconds(3f);
        }
    }

    private void OnEnable()
    {
        health.deathEvent.AddListener(OnDeath);
    }

    private void OnDisable()
    {
        health.deathEvent.RemoveListener(OnDeath);
    }

    private void OnDeath(DamageData damageData)
    {
        Destroy(gameObject);
    }

    private void FlipUp()
    {
        StartCoroutine(RotateToTarget(downRotationX, upRotationX, true));
    }

    private void FlipDown()
    {
        StartCoroutine(RotateToTarget(upRotationX, downRotationX, false));
    }

    IEnumerator RotateToTarget(float startX, float endX, bool useEasing)
    {
        for(float t = 0; t <= 1f; t += Time.deltaTime/speed)
        {
            float easedTime = Easings.EaseOutBounce(t);
            float xRot = Mathf.LerpAngle(startX, endX, useEasing ? easedTime : t);
            Vector3 rot = transform.eulerAngles;
            rot.x = xRot;
            transform.eulerAngles = rot;
            yield return null;
        }
    }
}
