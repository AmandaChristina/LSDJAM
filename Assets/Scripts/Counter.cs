using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField]
    GameObject showObj, hideObj;
    public static int _count;
    [SerializeField]
    int limit;
        
    void Update()
    {
        if(_count == limit)
        {
            showObj.SetActive(true);
            hideObj.SetActive(false);

            _count = 0;
        }
    }

    public static void AddToCount(int count)
    {
        _count += count;
    }

    
}
