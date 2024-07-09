using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    //Camera
    [SerializeField] float limitVerticalView = 20f;
    Player player;

    void Start()
    {
        InitialConfigCamera();
        player = GetComponentInParent<Player>();
        
    }

    
    void Update()
    {
       CameraMovement();
    }


    void InitialConfigCamera()
    {
        Vector3 newPosition;
        newPosition = Player.playerTransform.position;
        newPosition += new Vector3(0, 1.1f, 1f);
        transform.position = newPosition;
        transform.SetParent(Player.playerTransform);
        transform.rotation = Quaternion.identity;
    }

    public void CameraMovement()
    {
        
        float xRotate = Mathf.Clamp(player.GetMouseY(), -limitVerticalView, limitVerticalView);
        Vector3 newRotation = new Vector3(xRotate * MouseOptions.mouseSensibility/2f, player.transform.eulerAngles.y, 0f);
        transform.rotation = Quaternion.Euler(newRotation);

    }
}
