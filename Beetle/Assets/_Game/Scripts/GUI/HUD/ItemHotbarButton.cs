using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHotbarButton : MonoBehaviour
{
    public UnityEngine.UI.Button Button;

    [SerializeField] private UnityEngine.UI.Image itemIcon;
    [SerializeField] private TMPro.TextMeshProUGUI hotkeyText;
    [SerializeField] private UnityEngine.UI.Image cooldownImage;
    [SerializeField] private TMPro.TextMeshProUGUI cooldownText;
    [SerializeField] private TMPro.TextMeshProUGUI manaCostText;
    [SerializeField] private TMPro.TextMeshProUGUI usesText;

    private void Start()
    {
        //SetCooldown(0f, 0f);
    }

    public void Initialize(string hotkey)
    {
        hotkeyText.text = hotkey;
        itemIcon.enabled = false;
        SetAmount(0);
    }

    public void SetCooldown(float percent, float time)
    {
        if(time > 0f)
        {
            cooldownImage.enabled = true;
            cooldownText.enabled = true;

            cooldownImage.fillAmount = percent;
            cooldownText.text = time.ToString("F0");
        }
        else
        {
            cooldownImage.enabled = false;
            cooldownText.enabled = false;
        }
    }

    public void SetAmount(int amount)
    {
        if (amount > 0)
        {
            usesText.enabled = true;
            usesText.text = amount.ToString();
        }
        else
        {
            usesText.enabled = false;
        }
    }

    public void SetItem(ItemInstance itemInstance, ItemData itemData)
    {
        itemIcon.enabled = true;
        itemIcon.sprite = itemData.Icon;
        SetAmount(itemInstance.Amount);
    }

    public void Clear()
    {
        SetAmount(0);
        itemIcon.enabled = false;
    }
}
