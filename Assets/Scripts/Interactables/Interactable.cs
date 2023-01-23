 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent InteractableEvent;

    [SerializeField]
    Material selected;
    Material normal;

    void Start()
    {

        normal = gameObject.GetComponent<MeshRenderer>().material;
    }


    void Update()
    {
        OnDeselected();
    }

    public void OnSelected()
    {
        gameObject.GetComponent<MeshRenderer>().material = selected;
    }

    public void OnDeselected()
    {
        gameObject.GetComponent<MeshRenderer>().material = normal;
    }

    public void RemoveScript()
    {
        Destroy(GetComponent<Interactable>());
    }
}
