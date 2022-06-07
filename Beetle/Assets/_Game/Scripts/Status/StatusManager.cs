using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager
{
    private PlayerData playerData;
    private List<BaseStatus> allStatus = new List<BaseStatus>();

    public StatusManager(PlayerData characterData)
    {
        this.playerData = characterData;
    }

    public List<BaseStatus> GetAllStatus()
    {
        return allStatus;
    }

    public void AddStatus(BaseStatus status)
    {
        allStatus.Add(status);
        status.OnAdd(playerData);
    }

    public void RemoveStatus(BaseStatus status)
    {
        allStatus.Remove(status);
        status.OnRemove(playerData);
        //somehow search by type?
    }

    public void RemoveStatus(Type statusType, bool all = false)
    {
        for (int i = 0; i < allStatus.Count; i++)
        {
            if(allStatus[i].GetType() == statusType)
            {
                allStatus.RemoveAt(i);
                i--;
                if(!all)
                {
                    return;
                }
            }
        }
        //somehow search by type?
    }

    public void Update()
    {
        foreach(var status in allStatus)
        {
            status.OnUpdate(playerData); 
        }
    }
}
