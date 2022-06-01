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
    //Make a public feedbacks and make a new game object to hold the feed backs. Must create a animation event to refernce the void
    public virtual void Change()
    {
        ChangeWalk?.PlayFeedbacks();
    }
}
