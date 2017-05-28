using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    // Variable that contains the game over object
    public GameObject gameOverScreen;   
    // Varaiable needed for gameover bool
    bool gameOver;

	// Use this for initialization
	void Start () {
        // Delegate function for player death screen 
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
	}
	
	// Update is called once per frame
	void Update () {

        // Load game
		if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
	}

    // Method for delegate function
    void OnGameOver()
    {
        // Sets game over screen active
        gameOverScreen.SetActive(true);  
        // Sets game over to true
        gameOver = true;
    }    


}
