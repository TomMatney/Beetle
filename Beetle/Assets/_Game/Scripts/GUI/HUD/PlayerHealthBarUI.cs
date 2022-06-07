using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUI : MonoBehaviour
{
    private Health playerHealth = null;

    [SerializeField] private Image healthBarImage;
    [SerializeField] private TMPro.TextMeshProUGUI healthBarText;


    public void InitializeHealth(Health playerHealth)
    {
        this.playerHealth = playerHealth;
        UpdateHealthUI();
        playerHealth.damageTakenEvent.AddListener(OnDamageTaken);
    }

    private void OnEnable()
    {
        if(playerHealth)
        {
            playerHealth.damageTakenEvent.AddListener(OnDamageTaken);
        }
    }

    private void OnDisable()
    {
        if (playerHealth)
        {
            playerHealth.damageTakenEvent.RemoveListener(OnDamageTaken);
        }
    }

    private void OnDamageTaken(DamageData damageData)
    {
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        float healthPercentage = playerHealth.CurrentHealth / playerHealth.MaxHealth;
        healthBarImage.fillAmount = healthPercentage;
        healthBarText.text = playerHealth.CurrentHealth.ToString("F2") + "/" + playerHealth.MaxHealth;
    }
}
