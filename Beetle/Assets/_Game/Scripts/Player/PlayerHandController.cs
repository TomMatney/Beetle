using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;

    public Transform originalParent;
    public Transform weaponParent;

    public void SetHandsOnWeapon()
    {
        leftHand.parent = weaponParent;
        rightHand.parent = weaponParent;
    }

    public void SetHandsOnOriginal()
    {
        leftHand.parent = originalParent;
        rightHand.parent = originalParent;
    }
}
