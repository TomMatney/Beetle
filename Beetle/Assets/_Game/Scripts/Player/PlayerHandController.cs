using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;

    public Transform originalParent;
    public Transform weaponParent;

    [SerializeField] private Animator animator;

    public void SetHandsOnWeapon()
    {
        leftHand.parent = weaponParent;
        rightHand.parent = weaponParent;
        animator.Rebind();
        leftHand.localPosition = new Vector3(-.22f, .08f, -.34f);
        leftHand.localEulerAngles = new Vector3(-90f, 0f, 0f);
        rightHand.localPosition = new Vector3(-.23f, .08f, .65f);
        rightHand.localEulerAngles = new Vector3(-90f, 0f, 0f);
    }

    public void SetHandsOnOriginal()
    {
        leftHand.parent = originalParent;
        rightHand.parent = originalParent;
        animator.Rebind();
    }
}
