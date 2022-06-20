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

    Vector3 originalPosL;
    Vector3 originalPosR;
    Vector3 originalRotL;
    Vector3 originalRotR;

    private void Start()
    {
        animator.Rebind();
        originalPosL = leftHand.localPosition;
        originalRotL = leftHand.localEulerAngles;
        originalPosR = rightHand.localPosition;
        originalRotR = rightHand.localEulerAngles;
    }

    public void SetHandsOnWeapon()
    {
        rightHand.parent = weaponParent;
        leftHand.parent = weaponParent;
        animator.Rebind();
        leftHand.localPosition = new Vector3(-.22f, .08f, -.34f);
        leftHand.localEulerAngles = new Vector3(-90f, 0f, 0f);
        rightHand.localPosition = new Vector3(-.23f, .08f, .65f);
        rightHand.localEulerAngles = new Vector3(-90f, 0f, 0f);
    }

    public void SetHandsOnOriginal()
    {
        rightHand.parent = originalParent;
        leftHand.parent = originalParent;
        leftHand.localPosition = originalPosL;
        leftHand.localEulerAngles = originalRotL;
        rightHand.localPosition = originalPosR;
        rightHand.localEulerAngles = originalRotR;
        animator.Rebind();
    }
}
