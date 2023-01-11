using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counted : MonoBehaviour
{
    public void OnCount() {

        Counter.AddToCount(1);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void RemoveScript()
    {
        Destroy(GetComponent<Counted>());
    }
}
