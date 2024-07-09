using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] Animator pAnimator;
    bool _isSwimming;
    [SerializeField] CharacterController controller;

    bool move;

    void Start()
    {
               
    }


    void Update()
    {

       float  hMove = Input.GetAxis("Horizontal");
       float zMove = Input.GetAxis("Vertical");

        if (hMove != 0 || zMove != 0) move = true;
        else move = false;

        //print("H: " + hMove + ", Z: " + zMove + ", Walking: " + walking);

        pAnimator.SetBool("moving", move);

        _isSwimming = Movement.isSwimming;

        pAnimator.SetBool("swimming", _isSwimming);

    }
}
