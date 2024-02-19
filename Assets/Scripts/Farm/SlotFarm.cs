
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planting : MonoBehaviour
{

    [SerializeField] private bool enebleDig = true;

 
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    [SerializeField] private int digAmount;

    private int initialDigAmount;

    // Start is called before the first frame update
    void Start()
    {
        initialDigAmount = digAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Dig()
    {
        
        if(enebleDig)
        {
            
            digAmount--;

            if(digAmount <= initialDigAmount)
            {
                Debug.Log(digAmount);
                spriteRender.sprite = hole;
            }

            // if(digAmount <= 0)
            // {
            //     Debug.Log(digAmount);
            //     spriteRender.sprite = carrot;
            // }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("DigCollider"))
        {
            Debug.Log("Dig");

            Dig();
        }

    }
}
