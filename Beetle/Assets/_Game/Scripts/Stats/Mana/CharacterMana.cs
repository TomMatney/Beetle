using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMana : MonoBehaviour
{
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float manaRegen = 50f;

    public float MaxMana { get { return maxMana; } }

    public float CurrentMana { get; set; } = default;

    [System.NonSerialized] public UnityEvent<float> manaChangedEvent = new UnityEvent<float>();

    private void Awake()
    {
        CurrentMana = maxMana;
    }

    private void Start()
    {
        PlayerHUD.Instance.playerMana.InitializeMana(this);
    }

    private void Update()
    {
        if(CurrentMana < MaxMana)
        {
            CurrentMana = Mathf.Clamp(CurrentMana + (manaRegen * Time.deltaTime), 0f, MaxMana);
            manaChangedEvent.Invoke(CurrentMana);
        }
    }

    public bool CanUseMana(float amount)
    {
        return CurrentMana >= amount;
    }

    public void ChangeMana(float amount)
    {
        CurrentMana = Mathf.Clamp(CurrentMana + amount, 0f, MaxMana);

        manaChangedEvent.Invoke(amount);
    }

    public void ResetMana()
    {
        CurrentMana = maxMana;
        manaChangedEvent.Invoke(CurrentMana);
    } 
}
