/*
 * In this Script the players control and moving velocity is set
 * Players tigger cases and Death funtion is added 
 */

using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private float speed = 4f;
    private CharacterController characterController;
    private Vector3 moveVector;
    private float verticalVelocity = 0f;
    private readonly float gravity = 12f;
    
    private readonly float animationDuration = 2f;
    private float startTime;
    
    private bool isDead;
    public GameObject DeadMenu;
    public GameManager gamemanager;
    public HealthBar healthBar;

 

    // Start is called before the first frame update
    private void Start()
    {  
        isDead = false;
        characterController = GetComponent<CharacterController>();
   
        startTime = Time.time;    

    }

    // Update is called once per frame
    private void Update()
    {
        if (isDead) { return; }
        if (Time.time - startTime < animationDuration)
        {
            characterController.Move(speed * Time.deltaTime * moveVector); //vector.forward
            return;
        }

       
        // To check if on ground
        if (characterController.isGrounded)
        {
            verticalVelocity = -0.5f * Time.deltaTime;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // X - Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed; // From Keyboard
        moveVector.x = Mathf.Clamp(moveVector.x, -2, 2);
        // Y - Up and Down
        moveVector.y = verticalVelocity;
        // Z - Forward or Backward
        moveVector.z = speed;
        // characterController.Move(Vector3.forward * speed * Time.deltaTime); // to make player move forward according to fames
        characterController.Move(moveVector * Time.deltaTime);
        // Debug.Log(moveVector);


    }
    // to increase speed every 10 points
    public void SpeedSetUp(float increase)
    {
        speed = 2f + increase;
        Debug.Log("Speed = "+ speed);
    }
    
    // Collision of player with certain objects
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("object"))
        {
            onDeath("Dead due to object");
        }
        else if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("FirstAid"))
        {
            Destroy(other.gameObject);
            Debug.Log("Firstaid, + 10 secs");
            gamemanager.GetComponent<GameManager>().LifeUpTen();

        }
        else if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Water"))
        {
            Destroy(other.gameObject);
            Debug.Log("Water, + 5 secs ");
            gamemanager.GetComponent<GameManager>().LifeUpFive();

        }
        else { return; }
        
        
    }
    // This function is called when any gameOver scenario exists 
    public void onDeath(string reason)
    {
        Debug.Log(reason);
        isDead = true;
        // Destroy(other.gameObject);
        DeadMenu.SetActive(true);
        GetComponent<ScoreManager>().MenuCall();
        DeadMenu.GetComponent<DeadMenu>().ToggleEnd();
        gamemanager.GetComponent<GameManager>().stopTimer = true ;
        
    }




} 
