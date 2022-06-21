using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Beetle/ItemDatabase", order = 1)]

public class ItemDatabase : ScriptableObject
{
    public List<ItemData> Items;
}
