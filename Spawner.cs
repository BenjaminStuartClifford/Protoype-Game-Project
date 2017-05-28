using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Enemy array for spawner
    public GameObject[] enemyPrefab;

    // x,y seconds between spawns
    public Vector2 secondsBetweenSpawnsMinMax;

    // Next spawn time
    float nextSpawnTime;

    // x,y spawn min and max
    public Vector2 spawnSizeMinMax;

    // Direction enemy comes into screen
    public float spawnAngleMmax;

    // Screen size for spawner - needs to be across the top of the screen
    Vector2 screenHalfSize;

    // Use this for initialization
	void Start () {
        // Determines screen half size acoording to current dimensions. Dimensions can be changed in Unity using this method.
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);		
	}
	
	// Update is called once per frame
	void Update () {

        // This conditonal determines whether the next enemy will load and from what angle 
        if(Time.time > nextSpawnTime) {
            
            // Determines seconds between spawns based onthe difficulty (increases with time)
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());

            // Determine when nex t spawn will happen. Adds to current time at last frame
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            // Angle the enemy spawns (it's vector)
            float spawnAngle = Random.Range(-spawnAngleMmax, spawnAngleMmax);

            // Enemey size within a random range
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);

            // Start position for enemey
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + spawnSize);

            // Instantiate new enemy from array, and angle
            GameObject newEnemy = (GameObject)Instantiate(enemyPrefab[Random.Range(0,2)], spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));

            // Scale the new enemy according to the spawn size variable
            newEnemy.transform.localScale = Vector2.one * spawnSize;
        }
    }
}
