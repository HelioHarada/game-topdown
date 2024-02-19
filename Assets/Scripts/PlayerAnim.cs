using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    private Player player;


    private Animator anim;
    // Start is called before the first frame update



    /*

    animation sumary

    0 - Idle
    1 - Walking
    2 - Run
    3 - Roll
    4 - Cut
    5 - dig
    6 - watering
    7 - 

    */

    void Start()
    {
        player = GetComponent<Player>();
    
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        OnMoving();
        OnRunning();
        OnCutting();
        OnDigging();
        OnWatering();
    }

    #region 
    void OnMoving()
    {
        //  sqrMagnitude return the media of the Vector.
        if(player.direction.sqrMagnitude > 0)
        {   
            if(player.isRolling)
            {
                anim.SetTrigger("isRoll");
            }else{
                anim.SetInteger("transition", 1);
            }
           
        }else{
            anim.SetInteger("transition", 0);
        }

        if(player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2 (0,0);
        }

        if(player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2 (0,180);
        }
    }

    void OnRunning()
    {
        if(player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }
    }

    void OnDigging()
    {
        if(player.IsDigging)
        {
            anim.SetInteger("transition", 5);
        }
    }

    void OnCutting()
    {
       
        if(player.isCutting)
        {
            anim.SetInteger("transition",4);
        }
    }
   
   void OnWatering()
   {
    if(player.IsWatering )
    {
        anim.SetInteger("transition",6);
    }
   }
    #endregion


}
