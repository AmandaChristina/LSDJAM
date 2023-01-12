using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    Animator pAnimator;
    bool _isSwimming;

    void Start()
    {
        pAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        _isSwimming = Movement.isSwimming;

        if (_isSwimming) pAnimator.SetBool("swimming", true);
        else pAnimator.SetBool("swimming", false);
    }
}
