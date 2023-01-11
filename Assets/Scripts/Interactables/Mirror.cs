using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField]
    GameObject cenario1;
    [SerializeField]
    GameObject cenario2;
    [SerializeField]
    Material brokenMaterial;

    Interactable interactable;

    void Start()
    {
        interactable = gameObject.GetComponent<Interactable>();
    }


    public void ScenarySwap()
    {
        cenario1.SetActive(false);
        cenario2.SetActive(true);

        gameObject.GetComponent<MeshRenderer>().material = brokenMaterial;
        print("troquei de material");
        //interactable.InteractableEvent -= ScenarySwap;

    }
}
