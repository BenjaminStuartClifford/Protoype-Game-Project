using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // Speed varibale
    public float speed;

    // x,y min/max speed. This will chnage over time according to Difficulty class
    public Vector2 speedMinMax;

    // Variable for enemey death height
    public float visibleHeightThreshold;

	// Use this for initialization
	void Start () {

        // Increase the speed according to the difficulty. Lerp generates range between 0 and 1
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());

        // Amount the enemy needs to fall before it dies
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;

    }
	
	// Update is called once per frame
	public virtual void Update () {

        // Enemy falling speed 
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // If enemy falls below frame, kill it
        if (transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
	}
}
