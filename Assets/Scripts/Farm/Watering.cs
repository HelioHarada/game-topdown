using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField]private bool detectingPlayer;
    
    private PlayerItems player;
    // Start is called before the first frame update
    void Start()
    {
        // a unity vai buscar um objeto/script com o nome passado no parametro.
        player = FindObjectOfType<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
           
            if(player != null)
            {
                 player.addWater(10);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = true;
            Debug.Log("acesso");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }

    }
}
