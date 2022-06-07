using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarImage;
    [SerializeField] private TMPro.TextMeshProUGUI healthBarText;
    //Used to set visibility of health bar
    [SerializeField] private Canvas canvas;

    private Health health;

    [SerializeField] private bool visible = false;

    private void Start()
    {
        health = GetComponentInParent<Health>();
        OnDamageTaken(null);
        health.damageTakenEvent.AddListener(OnDamageTaken);
        SetVisible(visible);
    }
    
    private void Update()
    {
        Vector3 dir = Camera.main.transform.position - transform.position;
        dir.Normalize();
        transform.forward = -dir;
    }

    private void OnEnable()
    {
        if (health)
        {
            health.damageTakenEvent.AddListener(OnDamageTaken);
        }
    }


    private void OnDisable()
    {
        if (health)
        {
            health.damageTakenEvent.RemoveListener(OnDamageTaken);
        }
    }

    private void OnDamageTaken(DamageData damageData)
    {
        if(!visible)
        {
            SetVisible(true);
        }
        float healthPercentage = health.CurrentHealth / health.MaxHealth;
        healthBarImage.fillAmount = healthPercentage;
        healthBarText.text = health.CurrentHealth.ToString("F2") + "/" + health.MaxHealth;
    }

    private void SetVisible(bool visible)
    {
        this.visible = visible;
        canvas.enabled = visible;
    }
}
