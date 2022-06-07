using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies;
    [SerializeField] private List<Enemy> bosses;

    static private EnemyFactory Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError($"Instance of {nameof(EnemyFactory)} already exists");
        }
        else
        {
            Instance = this;
        }
    }

    public static Enemy GetRandomEnemy()
    {
        if (Instance == null)
        {
            Debug.LogError($"No instance of {nameof(EnemyFactory)}!");
            return null;
        }

        Enemy enemy = Instance.enemies.RandomItem();        
        return enemy;
    }

    //public static Enemy SpawnEnemy<T>()
    //{
    //    if (Instance == null)
    //    {
    //        Debug.LogError($"No instance of {nameof(EnemyFactory)}!");
    //        return null;
    //    }
    //    return Instance.enemies.RandomItem();
    //}

    public static Enemy GetEnemy(Enemy enemy)
    {
        if (Instance == null)
        {
            Debug.LogError($"No instance of {nameof(EnemyFactory)}!");
            return null;
        }
        var foundEnemy = Instance.enemies.Find(a => a == enemy);
        if(foundEnemy == null)
        {
            foundEnemy = Instance.bosses.Find(a => a == enemy);
        }
        return foundEnemy;
    }
}
