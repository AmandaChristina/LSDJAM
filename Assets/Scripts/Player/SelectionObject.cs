using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionObject : MonoBehaviour
{
    [SerializeField]
    Interactable interactable;
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
            interactable = hit.transform.gameObject.GetComponent<Interactable>();

            if (interactable != null)
            {

                interactable.OnSelected();

                //� aqui que preciso fazer a fun��o que puxa qualquer uma que o objeto tiver 
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.InteractableEvent.Invoke();
                }
            }


        }
    }
}
