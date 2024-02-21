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
    private bool _isWatering;

    private Rigidbody2D rb;
    private PlayerItems playerItems;

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
    public bool IsWatering { get => _isWatering; set => _isWatering = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerItems = GetComponent<PlayerItems>();
        initialSpeed = speed;
    }

    void Update()
    {
        OnInput();
        OnRoll();
        OnCut();
        OnDigging();
        OnWatering();
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

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            handlingObj = 3;
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
            rb.velocity = _direction * rollSpeed;
             
            // rb.MovePosition(rb.position* rollSpeed + _direction * initialSpeed * rollSpeed );
            isRolling = true;
            Invoke("DisableRoll", 0.01f);
             
        }



        if(Input.GetMouseButtonUp(1))
        {
            isRolling = false;
            rb.velocity = Vector2.zero;
            speed = initialSpeed;
        }


    }

    void DisableRoll()
    {
            isRolling = false;
            speed = initialSpeed;
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

    void OnWatering()
    {
        if(handlingObj == 3)
        {
            if(Input.GetMouseButtonDown(0) && playerItems.TotalWater > 0.1f)
            {
                IsWatering = true;
                speed = 0f;
            }

            if(Input.GetMouseButtonUp(0) || playerItems.TotalWater <= 0.1f)
            {
                IsWatering = false;
                speed = initialSpeed;
            }
        }

        if(IsWatering)
        {
            playerItems.TotalWater -= 0.01f;
        }
        
    }
    #endregion

    
}
