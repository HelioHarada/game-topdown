using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_Controller : MonoBehaviour
{
    public int waveQtd = 20;
    public GameObject NPC;
    public float delayBetweenSpawns = 2;
    private int spawnedCount = 0;

    public Transform startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        // startPosition.transform.position;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWave()
    {
        spawnedCount = 0;
        InvokeRepeating("SpawnNPC", delayBetweenSpawns, 1f);
        
    }

    public void SpawnNPC(){
        if(gameObject.activeSelf && spawnedCount <= waveQtd)
        {

            Instantiate(NPC, startPosition.position, Quaternion.identity);
            spawnedCount++;
        }else{
            CancelInvoke("SpawnNPC");
        }
    }

}
