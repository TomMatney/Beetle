using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeels : MonoBehaviour
{
    public MMFeedbacks ChangeWalk;
    
    //Make a public feedbacks and make a new game object to hold the feedbacks.
    //Called using an animationEvent
    public virtual void Change()
    {
        ChangeWalk?.PlayFeedbacks();
    }
}
