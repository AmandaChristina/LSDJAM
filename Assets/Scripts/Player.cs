using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variáveis
    //Base
    [HideInInspector] public static Transform playerTransform;
    [HideInInspector] public CharacterController controller;
    [HideInInspector] public Animator animator;

    PlayerCamera playerCamera;
    float _mouseY, _mouseX, _horizontal, _vertical;

    //Objetos
    [HideInInspector] public GameObject waterObj;

    //Movimentação
    Vector3 move;
    [SerializeField] float speed = 5f, gravity = 9f;

    //Nadar
    [SerializeField] float waterHeightOffset = 1.9f;

    //Animações
    [SerializeField] bool _isSwimming, _isMoving;
    public bool _isGrounded = true;

    //Máquina de Estado
    enum States { MOVE, SWIM, STOP } //Cria as opções
    [SerializeField]
    States _state; // cria a variável que vai receber a opção atual
    #endregion

    void Awake()
    {
        playerTransform = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

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

        // 
        if (!_isSwimming) PlayerOnGround();
        else Swimming();
      PlayerInWater();
      PlayerAnimations();
      _isGrounded = controller.isGrounded;


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
            print("Limite: " + (controller.height - waterHeightOffset) + "; Distancia água:" + waterDistance);
           if (waterDistance > controller.height - waterHeightOffset) _isSwimming = true;
           else _isSwimming = false;

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
        controller.Move(fall * Time.deltaTime * gravity);
        //if (!controller.isGrounded)
        //{
        //    controller.Move(fall * Time.deltaTime * gravity);
        //}
    }

    public void Swimming()
    {
        //Andar
        move = new Vector3(_horizontal, 0, _vertical).normalized;
        move = transform.TransformDirection(move);

        controller.Move(move * Time.deltaTime * speed);

        //Rotacionar Vertical
        gameObject.transform.Rotate(Vector3.up * _mouseX * MouseOptions.mouseSensibility);


        //Rotacionar Horizontal
        float limitVerticalView = 15f;
        float xRotate = Mathf.Clamp(_mouseY, -limitVerticalView, limitVerticalView);
        Vector3 newRotation = new Vector3(xRotate * MouseOptions.mouseSensibility / 2f, transform.eulerAngles.y, 0f);
        transform.rotation = Quaternion.Euler(newRotation);

    }

   void PlayerAnimations()
    {
        if (_horizontal != 0 || _vertical != 0) _isMoving = true;
        else _isMoving = false;

        animator.SetBool("moving", _isMoving);

        animator.SetBool("swimming", _isSwimming);

    }

}
