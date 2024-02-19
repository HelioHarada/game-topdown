using System;
using System.Collections;
using System.Collections.Generic;
// using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Speed control")]
    public float speed;
    public float initialSpeed;
    public float runSpeed = 1.5f;
    public float rollSpeed = 5.5f;

    // Control tool
   [Header("handle tool")]
     [SerializeField] private int handlingObj = 1;
    
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;

    private Rigidbody2D rb;

    [SerializeField]
    private Vector2 _direction;



    // Encapsulamento
    public Vector2 direction
    {
        get{ return _direction;}
        set{ _direction = value;}
    }

    public bool isRunning
    {
        get{ return _isRunning;}
        set{ _isRunning = value;}
    }

    public bool isCutting
    {
        get{ return _isCutting;}
        set{ _isCutting = value;}
    }

    public bool isRolling
    {
        get{ return _isRolling;}
        set{ _isRolling = value;}
    }

    public bool IsDigging { get => _isDigging; set => _isDigging = value; }



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    void Update()
    {
        OnInput();
        OnRoll();
        OnCut();
        OnDigging();

        HandleTool();
      
    }



    void FixedUpdate()
    {
       if(Input.GetKey(KeyCode.LeftShift))
       {
            OnRun();
       }else{
            OnMove(); 
       }    
    }


    void HandleTool()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            handlingObj = 1;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            handlingObj = 2;
        }
    }

    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        isRunning = false;
        rb.MovePosition(rb.position + _direction * speed * Time.fixedDeltaTime);

    }

    void OnRun()
    {   
        isRunning = true;
        rb.MovePosition(rb.position + _direction * speed * runSpeed * Time.fixedDeltaTime);
    }

    void OnRoll()
    {
        if(Input.GetMouseButtonDown(1))
        {
            
            speed = 0;
            rb.MovePosition(rb.position + _direction * initialSpeed * rollSpeed * Time.fixedDeltaTime);
            isRolling = true;
             
        }

        if(Input.GetMouseButtonUp(1))
        {
            isRolling = false;
            speed = initialSpeed;
        }


    }

    void OnDigging()
    {
        if(handlingObj == 2 && Input.GetMouseButtonDown(0))
        {
            IsDigging = true;
            speed = 0;
        }

        if(Input.GetMouseButtonUp(0))
        {
            speed = initialSpeed;
            IsDigging = false;
            
        }
        
    }

    void OnCut()
    {
        if(handlingObj == 1 && Input.GetMouseButtonDown(0))
        {
            isCutting = true;
            speed = 0;
           
        }
        if(Input.GetMouseButtonUp(0))
        {
            speed = initialSpeed;
            isCutting = false;
           
        }
    }

    #endregion

    
}
