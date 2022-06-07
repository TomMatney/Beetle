using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryListItemUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] TMPro.TextMeshProUGUI nameText;
    [SerializeField] TMPro.TextMeshProUGUI descriptionText;

    public void SetItem(ItemData item)
    {
        image.sprite = item.Icon;
        nameText.text = item.Name;
        descriptionText.text = item.Description;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
