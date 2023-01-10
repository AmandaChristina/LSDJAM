using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField]
    GameObject cenario1;
    [SerializeField]
    GameObject cenario2;

    void Start()
    {

    }


    public void ScenarySwap()
    {
        cenario1.SetActive(false);
        cenario2.SetActive(true);
        print("Toquei no espelho(" + (+1)+ ")");
    }
}
