using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOptions : MonoBehaviour
{
    public static float mouseSensibility = 5f;

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
