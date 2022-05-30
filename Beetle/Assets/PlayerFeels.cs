using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerFeels : MonoBehaviour
{
    public MMFeedbacks ChangeWalk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Change()
    {
        ChangeWalk?.PlayFeedbacks();
    }
}
