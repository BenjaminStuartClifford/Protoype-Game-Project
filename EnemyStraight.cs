using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStraight : Enemy {
     
	
	// Update is called once per frame
	public override void Update () {

        // Enemy falling speed 
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

        // If enemey falls below frame, kill it
        if (transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
	}
}
