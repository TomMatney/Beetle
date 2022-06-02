using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFeedback : MonoBehaviour
{
    public MMFeedbacks treeFeels;

    public virtual void Tree()
    {
        treeFeels?.PlayFeedbacks();
    }
}
