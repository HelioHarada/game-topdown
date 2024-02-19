using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeMove;
     [SerializeField] private float lifeTimeDrop;

    private Rigidbody2D rb;
    private float randomNumber;
    private float directionFall;
   

    [SerializeField] private float timeCount; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Drop();
        
    }

    void Drop()
    {
        randomNumber = Random.Range(0f, 1f);

        if(randomNumber < 0.5f)
        {
            directionFall = Random.Range(1f, -4f);;
        }else{
            directionFall = Random.Range(-1f, -4f);;
        }
        
        rb.velocity = new Vector2(directionFall, 1f);
        
    }


    void Update()
    {
          
        timeCount += Time.deltaTime;
        if(timeCount >= timeMove)
        {
            rb.bodyType = RigidbodyType2D.Static;
             Debug.Log(rb.gravityScale);
        }

        if(timeCount >= lifeTimeDrop)
        {
            if(gameObject.activeSelf)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collisor)
    {
        if(collisor.CompareTag("Player"))
        {
            collisor.GetComponent<PlayerItems>().totalWood++;
            if(gameObject.activeSelf)
            {
                
                Destroy(gameObject);
            }
        }
    }
}
