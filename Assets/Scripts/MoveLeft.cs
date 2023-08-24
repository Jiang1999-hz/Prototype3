using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30;
    private PlayerController playerControllerScript;
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //when the game is not over keep going left
        if(playerControllerScript.gameOver == false && !Input.GetKey(KeyCode.F)){
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        //speed up when holding F
        else if (playerControllerScript.gameOver == false && Input.GetKey(KeyCode.F))
        {
            transform.Translate(Vector3.left * speed * 2 * Time.deltaTime);
        }
        //destroy the outbound obstacles
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle")){
            Destroy(gameObject);
        }
    }
}
