using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public float speedBullet = 10f;

    private Vector2 DirectionBullet;

    public GameObject player;

    public float lifeTime = 3f;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        DirectionBullet = (player.transform.position - transform.position ).normalized;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = DirectionBullet * speedBullet;

      
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame

    void FixedUpdate()
    {
       
        rb.MovePosition(rb.position + DirectionBullet * speedBullet * Time.fixedDeltaTime);
    }

    void Update()
    {
        transform.eulerAngles += new Vector3(0f,0f, 3f);
    }

    void OnTriggerEnter2D(Collider2D collisor){


        if(collisor.CompareTag("NPC"))
        {
            Debug.Log("Colisior:" + collisor);

            NPC NPCmethods = collisor.GetComponent<NPC>();

            NPCmethods.TakeDamage(damage);
            
           
            if(gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }


  
}
