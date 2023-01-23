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

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    void Update()
    {

        CameraPosition();

        xRotate -= Input.GetAxis("Mouse Y");
        yPlayer = playerTransform.eulerAngles.y;
        print(yPlayer);

        newRotation = new Vector3(xRotate * MouseOptions.mouseSensibility, yPlayer, 0f);


        transform.rotation = Quaternion.Euler(newRotation);

    }
    void CameraPosition()
    {
        Vector3 newPosition;
        newPosition = playerTransform.position;
        newPosition += Vector3.up * 2f;
        transform.position = newPosition;
    }
}
