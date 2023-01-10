using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController controller;

    Vector3 move;

    float hMove;
    float zMove;
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float gravity;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>(); 
    }


    void Update()
    {
        hMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");

        move = new Vector3(hMove, 0, zMove).normalized;
        move = transform.TransformDirection(move);


        controller.Move(move * Time.deltaTime * speed);

        Vector3 fall = new Vector3(0, -1, 0);
        if (!controller.isGrounded)
        {
            controller.Move(fall * Time.deltaTime * gravity);
        }

    }

   
}
