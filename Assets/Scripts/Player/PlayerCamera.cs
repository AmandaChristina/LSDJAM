using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    Vector3 newRotation;

    float xRotate;
    float yPlayer;
    float limit = 20f;

    void Start()
    {

        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        CameraPosition();
    }

    void Update()
    {

        xRotate -= Input.GetAxis("Mouse Y");
        xRotate = Mathf.Clamp(xRotate, -limit, limit);
        yPlayer = playerTransform.eulerAngles.y;
        //print(yPlayer);

        newRotation = new Vector3(xRotate * MouseOptions.mouseSensibility, yPlayer, 0f);


        transform.rotation = Quaternion.Euler(newRotation);

    }
    void CameraPosition()
    {
        Vector3 newPosition;
        newPosition = playerTransform.position;
        newPosition += new Vector3(0, 1.1f,1f);
        transform.position = newPosition;
        transform.SetParent(playerTransform);
        transform.rotation = Quaternion.identity;

    }
}
