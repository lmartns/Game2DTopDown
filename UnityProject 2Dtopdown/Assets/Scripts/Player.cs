using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //variáveis
    public float speed;
    public float runSpeed;
    private Rigidbody2D rig;

    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private Vector2 _direction;

    //propriedades
    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    private void Update()
    {
        OnInput();
        OnRun();
        OnRolling();
    }


    private void FixedUpdate()
    {
        OnMove();
    }
    //organizar um bloco de código 
    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        //checando quando pressiono o botão
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //após pressionar shift esquerdo meu váriavel speed vai receber = 
            speed = runSpeed;
            _isRunning = true;

        }
        // checando se soltei a tecla 
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //após soltar a variável speed recebe 
            speed = initialSpeed;
            _isRunning = false;

        }
    }

    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isRolling = false;
        }
    }

    #endregion

}
