using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManaBarUI : MonoBehaviour
{
    private CharacterMana playerMana = null;

    [SerializeField] private Image manaBarImage;
    [SerializeField] private TMPro.TextMeshProUGUI manaBarText;

    public void InitializeMana(CharacterMana playerMana)
    {
        this.playerMana = playerMana;
        UpdateManaUI();
        playerMana.manaChangedEvent.AddListener(OnManaChanged);
    }

    private void OnEnable()
    {
        if(playerMana)
        {
            playerMana.manaChangedEvent.AddListener(OnManaChanged);
        }
    }

    private void OnDisable()
    {
        if (playerMana)
        {
            playerMana.manaChangedEvent.RemoveListener(OnManaChanged);
        }
    }

    private void OnManaChanged(float amount)
    {
        UpdateManaUI();
    }

    private void UpdateManaUI()
    {
        float manaPercentage = playerMana.CurrentMana / playerMana.MaxMana;
        manaBarImage.fillAmount = manaPercentage;
        manaBarText.text = playerMana.CurrentMana.ToString("F2") + "/" + playerMana.MaxMana;
    }
}
