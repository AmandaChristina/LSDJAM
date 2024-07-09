using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variáveis
    //Base
    public static Transform playerTransform;
    public CharacterController controller;
    public Animator animator;

    [SerializeField] PlayerCamera playerCamera;
    float _mouseY, _mouseX, _horizontal, _vertical;

    //Objetos
    GameObject waterObj;

    //Movimentação
    Vector3 move;
    [SerializeField] float speed = 5f, gravity = 9f;

    //Nadar
    [SerializeField]float waterHeightOffset = 1.9f;

    //Animações
    bool _isSwimming, _isMoving;

    //Máquina de Estado
    enum States { MOVE, SWIM, STOP } //Cria as opções
    [SerializeField]
    States _state; // cria a variável que vai receber a opção atual
    #endregion

    void Awake()
    {
        playerTransform = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        waterObj = GameObject.Find("Water");
        playerCamera = GameObject.Find("Main Camera").GetComponent<PlayerCamera>();
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        SetInputs();

        #region Máquina de Estado
        //switch (_state)
        //{
        //    case States.MOVE:
        //        playerMovement.Walking();
        //        break;

        //    case States.SWIM:
        //        playerMovement.Swimming();
        //        break;

        //    case States.STOP:
        //        //print("Estou parado");
        //        break;

        //    default:
        //        playerMovement.Walking();
        //        break;
        //}

       

        #endregion

        PlayerInWater();
        PlayerOnGround();
        PlayerAnimations();


    }

    #region Inputs
    public void SetInputs()
    {
        _mouseY -= Input.GetAxis("Mouse Y");
        _mouseX = Input.GetAxis("Mouse X");

        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        
    }


    public float GetMouseX()
    {
        return _mouseX;
    }

    public float GetMouseY()
    {
        return _mouseY;
    }

    public float GetHorizontal()
    {
        return _horizontal;
    }

    public float GetVertical()
    {
        return _vertical;
    }
    #endregion

    void SwitchStates(States state)
    {
        _state = state;
    }

 
    void PlayerInWater()
    {
        if (waterObj != null)
        {
            float yPlayer = transform.position.y;
            float yWater = waterObj.transform.position.y;

            float waterDistance = yWater - yPlayer;

            while (waterDistance > controller.height - waterHeightOffset)
            {
                _isSwimming = true;
                Swimming();
                
            }
            _isSwimming = false;

        }
    }

    void PlayerOnGround()
    {
        if (controller.isGrounded) Walking();

        else Falling();
        
    }



    public void Walking()
    {
        

        //Andar
        move = new Vector3(_horizontal, 0, _vertical).normalized;
        move = transform.TransformDirection(move);

        controller.Move(move * Time.deltaTime * speed);

        //Rotacionar
        gameObject.transform.Rotate(Vector3.up * _mouseX * MouseOptions.mouseSensibility);


  

    }
    public void Falling()
    {
        Vector3 fall = new Vector3(0, -1, 0);
        if (!controller.isGrounded)
        {
            controller.Move(fall * Time.deltaTime * gravity);
        }
    }

    public void Swimming()
    {
        
    }

   void PlayerAnimations()
    {
        if (_horizontal != 0 || _vertical != 0) _isMoving = true;
        else _isMoving = false;
        animator.SetBool("moving", _isMoving);

        animator.SetBool("swimming", _isSwimming);

    }

}
