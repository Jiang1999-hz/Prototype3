using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] obstaclePrefeb;
    private Vector3 spawnPos = new Vector3(25,0,0);
    private float startDelay = 2;
    public float repeatRate = 2;
    private PlayerController playerControllerScript;
    public int indexMax = 3;
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
        int obstacleindex = Random.Range(0,indexMax);
        if(playerControllerScript.gameOver == false){
            Instantiate(obstaclePrefeb[obstacleindex],spawnPos,obstaclePrefeb[obstacleindex].transform.rotation);
        }
        //change the repeatRate after spawning one obstacle
        repeatRate = Random.Range(0.1f,10f);
        startDelay = Random.Range(0.1f,2.5f);
        CancelInvoke();
        InvokeRepeating("SpawnObstacle",startDelay,repeatRate);
    }
}
