using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGainedPreviewPanel : MonoBehaviour
{
    [SerializeField] private ItemGainedPanelElement itemGainedPanelPrefab;

    private static ItemGainedPreviewPanel Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError($"Instance of {nameof(ItemGainedPreviewPanel)} already exists!");
        }
        else
        {
            Instance = this;
        }
    }

    public static void AddItem(ItemData item, int count)
    {
        var newPanel = Instantiate(Instance.itemGainedPanelPrefab, Instance.transform);
        newPanel.Initialize(item.Icon, count);
        Destroy(newPanel.gameObject, 3f);
    }
}
