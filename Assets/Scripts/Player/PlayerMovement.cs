using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player
{
 
    Vector3 move;

    //Vars of Move
    float hMove, zMove;
    float hRotate, yRotate;
    [SerializeField]
    float speed = 5f, gravity;
    [SerializeField]
    float limitVerticalView = 20f;


    public void Walking()
    {
        //Queda
        Vector3 fall = new Vector3(0, -1, 0);
        if (!controller.isGrounded)
        {
            controller.Move(fall * Time.deltaTime * gravity);
        }

        //Andar
        move = new Vector3(GetHorizontal(), 0, GetVertical()).normalized;
        move = transform.TransformDirection(move);

        controller.Move(move * Time.deltaTime * speed);

        //Rotacionar

        //gameObject.transform.Rotate(Vector3.up * hRotate * MouseOptions.mouseSensibility);

        //yPlayer = playerTransform.eulerAngles.y;
        //newRotation = new Vector3(xRotate * MouseOptions.mouseSensibility, yPlayer, 0f);
        //transform.rotation = Quaternion.Euler(newRotation);

        CameraMovement();

    }
    public void CameraMovement()
    {
        float xRotate = GetMouseX();
        Mathf.Clamp(xRotate, -limitVerticalView, limitVerticalView);

    }


    public void Swimming()
    {

    }

}
