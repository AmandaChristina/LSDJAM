using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] Animator pAnimator;
    bool _isSwimming;
    [SerializeField] CharacterController controller;

    bool walking;

    void Start()
    {
               
    }


    void Update()
    {

       float  hMove = Input.GetAxis("Horizontal");
       float zMove = Input.GetAxis("Vertical");

        if (hMove != 0 || zMove != 0) walking = true;
        else walking = false;

        print("H: " + hMove + ", Z: " + zMove + ", Walking: " + walking);

        pAnimator.SetBool("walking", walking);
        _isSwimming = Movement.isSwimming;

        //if (_isSwimming) pAnimator.SetBool("swimming", true);
        //else pAnimator.SetBool("swimming", false);
    }
}
