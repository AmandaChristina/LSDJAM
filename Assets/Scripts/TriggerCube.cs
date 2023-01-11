using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCube : MonoBehaviour
{
    public UnityEvent TriggerEnter, TriggerExit;


    void  OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            TriggerEnter.Invoke();
        }
    }

    void OnTriggerExit(Collider trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            TriggerExit.Invoke();
        }
    }
}
