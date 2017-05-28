using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

    // Unity variable container for health text
    public Text healthUI;

    // Unity variable container for score text
    public Text scoreUI;

    // Use this for initialization
    void Start () {
        // Dlegate functions for player controller
        FindObjectOfType<PlayerController>().OnPlayerStart += OnGameStart;
        FindObjectOfType<PlayerController>().OnPlayerUpdate += OnGameUpdate;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    // This method ensures score and health present when the game starts
    //  Will be used by delegate function in player controller
    void OnGameStart()
    {   healthUI.text = PlayerController.currentHealth.ToString(); 
        scoreUI.text = PlayerController.playerScore.ToString(); 
    }

    // This method ensures score and health can update
    //  Will be used by delegate function in player controller
    void OnGameUpdate()
    {
        healthUI.text = PlayerController.currentHealth.ToString();
        scoreUI.text = PlayerController.playerScore.ToString();
    }


}
