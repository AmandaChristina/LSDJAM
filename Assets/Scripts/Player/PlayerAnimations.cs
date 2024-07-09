using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : Player
{
    [SerializeField] Animator pAnimator;
    bool _isSwimming, _isMoving;

    void Start()
    {
               
    }


    void Update()
    {

        if (GetHorizontal() != 0 || GetVertical() != 0) _isMoving = true;
        else _isMoving = false;
        pAnimator.SetBool("moving", _isMoving);

       // _isSwimming = Movement.isSwimming;

        pAnimator.SetBool("swimming", _isSwimming);

    }
}
