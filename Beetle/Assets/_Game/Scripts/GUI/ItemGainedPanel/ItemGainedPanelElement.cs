using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGainedPanelElement : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI amountText;
    [SerializeField] private UnityEngine.UI.Image itemImage;

    public void Initialize(Sprite icon, int amount)
    {
        itemImage.sprite = icon;
        amountText.text = "+" + amount;
    }
}
