using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    private int index;

    public LayerMask player;
    public float atackRange;
    public List<Transform> paths = new List<Transform>();



    public GameObject Bullet;
    public float fireRate;
    private float nextFireTime;
    // Start is called before the first frame update


    // Update is called once per frame


    void FixedUpdate(){
        RangeAtack();
    }

    void RangeAtack(){
        Collider2D range = Physics2D.OverlapCircle(transform.position, atackRange, player);

        if(range!= null)
        {
            if (Time.time >= nextFireTime)
            {
                Shoot(); // Chame o método de disparo
                nextFireTime = Time.time + 1f / fireRate; // Atualize o tempo do próximo tiro
            }
           
        }else{
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, atackRange);
    }

    void Shoot()
    {
        Vector3 shooterPosition = transform.position;
        Instantiate(Bullet,shooterPosition,Quaternion.identity);
    }

    
        
}
