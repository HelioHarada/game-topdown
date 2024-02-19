using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private int healthTree = 5;
    [SerializeField] private Animator anima; 

    [SerializeField] private ParticleSystem particle;

    [SerializeField] private bool enableDrop = true;

    public GameObject colectableWood;


    // Start is called before the first frame update
    void Start()
    {
        
        anima = GetComponent<Animator>();
    }

    public void CreateWoodDrop(int times = 1){
        for (int i = 0; i < times; i++)
        {
             Instantiate(colectableWood ,transform.position,transform.rotation);
        }
       
    }


    //  Tree Hit
    public void OnHit()
    {   
        // active animatio of tree was hitting and lower the healh tree
        anima.SetTrigger("hit");
        healthTree--;

        // Check if the tree can drop and ilive
        if(enableDrop)
        {
            particle.Play();
            // call the methods to drop 1 item
            CreateWoodDrop();

        // Destroy the Tree
            if(healthTree <= 0)
            {
                // Disable the drop tree
                enableDrop = false;
                float randomPercent = Random.Range(0f, 1f);
                
                // porcent of drop in the final tree.
                if(randomPercent < 0.5f)
                {
                    // 50%
                    CreateWoodDrop(3);
                }else if(randomPercent <= 0.8f)
                    {
                        // 30%
                        CreateWoodDrop(4);
                    }else{
                        // 20%
                        CreateWoodDrop(6);
                    }
                
            anima.SetTrigger("cut");
        
            }
        }
      

    }


    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("HitCollider"))
        {
            OnHit();
           
        }
    }
}
