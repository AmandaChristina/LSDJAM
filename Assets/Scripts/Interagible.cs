using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interagible : MonoBehaviour
{
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
}
