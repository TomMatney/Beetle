using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHotbarButton : MonoBehaviour
{
    public UnityEngine.UI.Button Button;

    [SerializeField] private UnityEngine.UI.Image abilityIcon;
    [SerializeField] private TMPro.TextMeshProUGUI hotkeyText;
    [SerializeField] private UnityEngine.UI.Image cooldownImage;
    [SerializeField] private TMPro.TextMeshProUGUI cooldownText;
    [SerializeField] private TMPro.TextMeshProUGUI manaCostText;
    [SerializeField] private TMPro.TextMeshProUGUI usesText;

    private void Start()
    {
        SetCooldown(0f, 0f);
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

    public void SetUses(int uses)
    {
        usesText.enabled = true;
        usesText.text = uses.ToString();
    }

    public void Initialize(string hotkey)
    {
        hotkeyText.text = hotkey;
    }

    public void SetItem(ItemInstance itemInstance, ItemData itemData)
    {
        abilityIcon.sprite = itemData.Icon;
        if(itemInstance.Count > -1)
        {
            usesText.enabled = true;
            usesText.text = itemInstance.Count.ToString();
        }
        else
        {
            usesText.enabled = false;
        }
    }
}
