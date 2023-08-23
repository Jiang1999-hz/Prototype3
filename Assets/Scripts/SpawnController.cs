using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject obstaclePrefeb;
    private Vector3 spawnPos = new Vector3(25,0,0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        //spawn the obstacle at intervals
        InvokeRepeating("SpawnObstacle",startDelay,repeatRate);
        //call gameplayerScript
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //spawn the obstacle
    void SpawnObstacle(){
        if(playerControllerScript.gameOver == false){
            Instantiate(obstaclePrefeb,spawnPos,obstaclePrefeb.transform.rotation);
        }
    }
}
