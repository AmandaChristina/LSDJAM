using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    GameObject pCamera;
    Vector3 pRotation;

    float hRotate;
    float yRotate;
    float xCamera;

    void Start()
    {
        pCamera = GameObject.Find("Main Camera");

    }

    void Update()
    {
        xCamera = pCamera.transform.rotation.x;

        hRotate = Input.GetAxis("Mouse X");
        yRotate = Input.GetAxis("Mouse Y");

        //xCamera = Mathf.Clamp(xCamera, -0.57f, 0.7f);
        //xCamera = Mathf.Clamp(xCamera, -90f, 50f);

        gameObject.transform.Rotate( Vector3.up * hRotate * MouseOptions.mouseSensibility);
        pCamera.transform.Rotate( Vector3.right * -yRotate * MouseOptions.mouseSensibility);

    }
}
