using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    enum States { MOVE, SWIM, UP,STOP} //Cria as op��es
    [SerializeField]
    States _state; // cria a vari�vel que vai receber a op��o atual

    GameObject waterObj;
    CharacterController controller;
    Vector3 move;

    bool isMoving, isStoping;
    public static bool isSwimming;

    //Vars of Move
    float hMove, zMove;
    float hRotate, yRotate;
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float gravity;

    //Vars of Swim


    void Start()
    {
        waterObj = GameObject.Find("Water");
        controller = gameObject.GetComponent<CharacterController>();
        isMoving = true;

    }


    void Update()
    {

        #region M�quina de Estado
        switch (_state)
        {
            case States.MOVE:
                Walking();
                Falling();
                break;

            case States.SWIM:
                Swimming();
                break;

            case States.UP:
                StartCoroutine(GetOutWater());
                break;

            case States.STOP:
                print("Estou parado");
                break;

            default:
                Walking();
                Falling();
                break;
        }
        #endregion

        //Verificar se est� nadando
        if(waterObj != null)
        {
            float yPlayer = transform.position.y;
            float yWater = waterObj.transform.position.y;

            float waterDistance = yWater - yPlayer;

            if (waterDistance > -controller.height / 2.3f)
            {
                isMoving = false;
                isSwimming = true;
            }

            else
            {
                isSwimming = false;
                
            }
        }

        if (isSwimming) SwitchStates(States.SWIM);
        else if (!isSwimming && !isMoving) SwitchStates(States.UP);
        else if (isMoving)SwitchStates(States.MOVE);


    }

    void GettingAxis()
    {
        hMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        hRotate = Input.GetAxis("Mouse X");
        yRotate = Input.GetAxis("Mouse Y");
    }

    void Walking()
    {

        GettingAxis();

        gameObject.transform.Rotate(Vector3.up * hRotate * MouseOptions.mouseSensibility);

        move = new Vector3(hMove, 0, zMove).normalized;
        move = transform.TransformDirection(move);

        controller.Move(move * Time.deltaTime * speed);


    }

    void Falling()
    {
        Vector3 fall = new Vector3(0, -1, 0);
        if (!controller.isGrounded)
        {
            controller.Move(fall * Time.deltaTime * gravity);
        }
    }

    //void Swimming()
    //{
    //    Walking();
    //    transform.Rotate(Vector3.right * -Input.GetAxis("Mouse Y") * Time.deltaTime * 100f);

    //}
    void Swimming()
    {
        GettingAxis();
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);

        if (transform.eulerAngles.x == Mathf.Clamp(transform.eulerAngles.x, 70f, 110f)) { 

            Vector3 rotateSwimming = new Vector3(100f * Time.deltaTime * -yRotate, 100f * Time.deltaTime * hMove, 0f);
            transform.Rotate(rotateSwimming);
            transform.Translate(0f,0f, speed * Time.deltaTime * zMove);
            //transform.Rotate(100f * Time.deltaTime * -yRotate, 100f * Time.deltaTime * hMove, 0f) ;

        }

    }

    IEnumerator GetOutWater()
    {
        // transform.rotation = Quaternion.identity; //deixa perfeitamente zerado
       // transform.rotation = Quaternion.Euler(Vector3.up * 90f);
        yield return new WaitForSeconds(0.1f);
        isMoving = true;
        SwitchStates(States.MOVE);

    }

    void SwitchStates(States state)
    {
        _state = state;
    }

}
