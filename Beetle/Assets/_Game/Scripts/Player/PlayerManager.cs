using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager Instance;

    private Dictionary<ulong, PlayerData> characters = new Dictionary<ulong, PlayerData>();

    [System.NonSerialized] public UnityEvent<PlayerData> characterAddedEvent = new UnityEvent<PlayerData>();
    [System.NonSerialized] public UnityEvent<PlayerData> characterRemovedEvent = new UnityEvent<PlayerData>();

    void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError($"Instance of {nameof(PlayerManager)} already exists");
        }
        else
        {
            Instance = this;
        }
    }

    public static void RegisterPlayer(PlayerData character, ulong ownerClientId)
    {
#if UNITY_EDITOR
        if(Instance.characters.ContainsKey(ownerClientId))
        {
            Debug.LogError($"{ character} is already registed to a characterData");
        }
        else
#endif
        {
            Instance.characters.Add(ownerClientId, character);
        }
        Instance.characterAddedEvent.Invoke(character);
    }

    public static void RemovePlayer(ulong clientNetworkId)
    {
        var character = GetCharacterFromNetworkId(clientNetworkId);
        Instance.characters.Remove(clientNetworkId);
        Instance.characterRemovedEvent.Invoke(character);
    }

    public static List<PlayerData> GetPlayers()
    {
        return new List<PlayerData>(Instance.characters.Values);
    }

    public static PlayerData GetLocalPlayer()
    {
        return FindObjectOfType<PlayerData>();
    }

    public static PlayerData GetCharacterFromNetworkId(ulong clientNetworkId)
    {
        PlayerData characterData = null;
        if(Instance.characters.TryGetValue(clientNetworkId, out characterData))
        {
            Debug.LogWarning($"No {nameof(PlayerData)} with clientNetworkId: {clientNetworkId}");
        }
        return characterData;
    }
}
