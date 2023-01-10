using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionObject : MonoBehaviour
{
    [SerializeField]
    Interagible interagible;
    [SerializeField]
    float range = 1000f;

    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit, range)){

            #region debug
            //Debug
            Debug.DrawLine(transform.position, hit.point, Color.blue);
            //print(hit.transform.name);
            #endregion
            interagible = hit.transform.gameObject.GetComponent<Interagible>();

            if (interagible != null)
            {
                
                interagible.OnSelected();

                //é aqui que preciso fazer a função que puxa qualquer uma que o objeto tiver 
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<GoToScene>().GoToTheScene() ;
                    hit.transform.gameObject.GetComponent<Mirror>().ScenarySwap();
                }
            }


        }
    }
}
