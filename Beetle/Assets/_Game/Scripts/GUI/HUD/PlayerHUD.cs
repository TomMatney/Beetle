using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] public PlayerHealthBarUI playerHealth;
    [SerializeField] public PlayerManaBarUI playerMana;
    [SerializeField] public ItemHotbar itemHotbar;

    public static PlayerHUD Instance { private set; get; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError($"Instance of {nameof(PlayerHUD)} already exists");
        }
        else
        {
            Instance = this;
        }
    }
}
