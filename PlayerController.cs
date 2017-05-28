using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

    // Attempt at enums, but couldn't get them to show in inspector
    //   public enum PlayerStats
    //   {
    //      startingHealth        
    //   }
    //   public PlayerStats playerStats;
    
        
    // Health and score variables
    //  Set and get playerHealth
    public int playerHealth
    {
        get { return startingHealth; }
        set { startingHealth = value; }
    }
    public int startingHealth = 10;

    public static int currentHealth;
    public static int playerScore = 0;       

    
    // Player move speed intialised
    public float speed = 7;

    // Delegate functions. These are here to separate the user interface
    //  functionality form the main player script
    public event Action OnPlayerDeath;
    public event Action OnPlayerStart;
    public event Action OnPlayerUpdate;

    // For the screen half width calculation
    float screenHalfWidth;

    // Material array for player
    public Material[] playerMaterial;

    // Renderer object variable for player trigger methods
    private Renderer rend;

    // Constructor to assign starting health
    void Awake()
    {
        // Instantiate current health
        currentHealth = startingHealth;
    }


    // Constructor to assign game start variables
    void Start () {

        // Get renderer for player materials
        rend = GetComponent<Renderer>();

        // Enable player material to be used 
        rend.enabled = true;
        
        // Associate player material to player
        rend.sharedMaterial = playerMaterial[0];        

        // Calculate half-player width for screen wrap calculation
        float halfPlayerWidth = transform.localScale.x / 2f;

        // Find screen half width: aspect ration * orthographic size
        //   half the player width needs to be added
        //      
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;

	}
	
	// Update is called once per frame
	void Update () {

        // get the direction of the player based on keyboard input form the user (direction)
        float inputX = Input.GetAxisRaw("Horizontal");

        // velocity equals direction * speed
        float velocity = inputX * speed;

        // get the move amount by multiplying the Vecotr2(1,0) * velocity * by the time since the last frame
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        // if player moves off left edge of screen instantiate new vector 2 
        // transform on opposite side of screen (Vector2 screenHalfwidth, transform.position.y)
        if (transform.position.x < -screenHalfWidth)
        {
            transform.position = new Vector2(screenHalfWidth, transform.position.y);
        }

        // Do the same thing for the right hand of the screen
        if (transform.position.x > screenHalfWidth)
        {
            transform.position = new Vector2(-screenHalfWidth, transform.position.y);
        }        
    }

    // Method detemrines what happens if player is hit by an
    // enemy with a given material
    //  If the material is the same as the player one is added to the player score
    //  If the material is different the player takes one point of damage and 
    //  inherits the material
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Block Shader One")
        {
            if (rend.sharedMaterial == playerMaterial[0])
            {
                playerHit();
                if (currentHealth == 0)
                {
                    playerDeath();
                }
                rend.sharedMaterial = playerMaterial[1];
            }
            else
            {
                playerScore += 1;
            }

            if (OnPlayerUpdate != null)
            {
                OnPlayerUpdate();
            }


        }

        if (col.tag == "Block Shader Two")
        {
            if (rend.sharedMaterial == playerMaterial[1])
            {
                playerHit();
                if (currentHealth == 0)
                {
                    playerDeath();
                }
                rend.sharedMaterial = playerMaterial[0];
            }
            else
            {
                playerScore += 1;
            }

            if (OnPlayerUpdate != null)
            {
                OnPlayerUpdate();
            }
        }
    }


    // Method for when player is hit
    public void playerHit()
    {        
        currentHealth -= 1;
    }

    // Method for player death
    public void playerDeath()
    {
        if (OnPlayerDeath != null)
        {
            OnPlayerDeath();
        }
        Destroy(gameObject);
    }

    
    
}
