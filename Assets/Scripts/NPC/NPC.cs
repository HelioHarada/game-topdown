using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public List<Transform> paths = new List<Transform>();
    

    public float speed;
    private int index;

    public bool showing;
     private Transform child;
     private Animator anima;

     public int totalHealth = 3; 

     void Start(){
        child = transform.Find("textInstruction");
        anima = GetComponent<Animator>();
        

     }
   


 
    void Update()
    {
        
    

     if(!DialogueControl.instance.IsShowing)
     {
        move();
     }else{
        anima.SetBool("isWalking", false);
     }
    
   
    }

    #region NPC movement
        void move(){
            anima.SetBool("isWalking", true);
        //  MoveTowards move um ponto de origem em direção a um ponto de destino com uma certa velocidade máxima.
            transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);
            
        ;        //  calcula a distância entre dois pontos (item1, item2) retorna zero se estiver na mesma posição
            if(Vector2.Distance(transform.position, paths[index].position) < 0.1f)
            {
                if(index < paths.Count -1)
                {
                    index++;
                    // index = Random.Range(0, paths.Count-1);

                }else{
                    index = 0;
                }
            }

            Vector2 direction = paths[index].position - transform.position;



            if(direction.x < 0)
            {
                transform.eulerAngles = new Vector2(0f, -180f);
                
            }
            if(direction.x > 0)
            {
                transform.eulerAngles = new Vector2(0f, 0f);
            }

            // trava a rotação do texto em cima do NPC
            if (child != null) {
                
                child.eulerAngles = new Vector2(0f, 0f);
            }
    }
    #endregion

    #region TD Health
    public void TakeDamage(int damage)
    {

        totalHealth -= damage;
        Debug.Log(totalHealth);
        if(totalHealth <= 0)
        {
            Destroy(gameObject);
        }
    }



    #endregion

}

