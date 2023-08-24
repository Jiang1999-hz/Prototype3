using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip JumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    private bool checkDoubleJump = true;
    private int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        //initial playerRb
        playerRb = GetComponent<Rigidbody>();
        //define gravityModifier
        Physics.gravity *= gravityModifier;
        //initial animator
        playerAnim = GetComponent<Animator>();
        //initial playerAudio
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //jump and double jump
        if(Input.GetKeyDown(KeyCode.Space) && (isOnGround || checkDoubleJump) && !gameOver){
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            if(isOnGround){
                isOnGround = false;
            }
            else if (!isOnGround && checkDoubleJump){
                checkDoubleJump = false;
            }
            dirtParticle.Stop();
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(JumpSound,1.0f);
        }
        //speed up when holding F
        if(Input.GetKey(KeyCode.F)){
            //animation speed up
            playerAnim.speed = 10;
        }else{
            playerAnim.speed = 1;
        }

        //as long as the game is not over, points++
        if(!gameOver && !Input.GetKey(KeyCode.F)){
            points++;
            Debug.Log(points);
        }
        else if (!gameOver && Input.GetKey(KeyCode.F))
        {
            points = points + 2;
            Debug.Log(points);
        }


    }
    //if player is not on the ground, should not be able to jump
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
            dirtParticle.Play();
            checkDoubleJump = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle")){
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound,1.0f);
        }
    }
}
