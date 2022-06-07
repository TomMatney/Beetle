using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStatus
{
    public float duration;
    protected StatusManager statusManager;

    public BaseStatus(StatusManager statusManager) 
    {
        this.statusManager = statusManager;
    }

    public abstract void OnAdd(PlayerData characterData);

    public abstract void OnRemove(PlayerData characterData);

    public abstract void OnUpdate(PlayerData characterData);
}
