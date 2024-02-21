
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planting : MonoBehaviour
{

    [SerializeField] private bool enebleDig = true;



    [Header("Componets")]
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [SerializeField] private int digAmount;

  [Header("Settings")]
    [SerializeField]private int initialDigAmount;
    [SerializeField] private bool detectingWater;
    [SerializeField] private float WaterAmount; 
    [SerializeField] private float currentWater; 
    private bool isHole;
    PlayerItems playerItems;

    // Start is called before the first frame update
    void Start()
    {
        playerItems = FindAnyObjectByType<PlayerItems>();
        initialDigAmount = digAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHole)
        {
            if(detectingWater)
            {
                currentWater += 0.01f;
            }

            // Encheu total de agua nessesario
            if(currentWater >= WaterAmount)
            {
                spriteRender.sprite = carrot;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    spriteRender.sprite = hole;
                    playerItems.TotalCarrots++;
                    currentWater = 0f;
                }
            }
        }


        
    }

    void Dig()
    {
        
        if(enebleDig)
        {
            
            digAmount--;

            if(digAmount <= initialDigAmount)
            {
                spriteRender.sprite = hole;
                isHole = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("DigCollider"))
        {
            Debug.Log("Dig");

            Dig();
        }

        if(collider.CompareTag("WaterCollider"))
        {
            detectingWater = true;
        }

    }


    private void OnTriggerExit2D(Collider2D collider)
    {

        if(collider.CompareTag("WaterCollider"))
        {
            detectingWater = false;
        }

    }
}
