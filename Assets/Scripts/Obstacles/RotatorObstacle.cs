using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorObstacle : Obstacle {

	// Use this for initialization
	void Start () {
        SetDirection();
	}
	
	// Update is called once per frame
	void Update () {
        movingObstacle();
	}

    protected override void movingObstacle()
    {
        switch(dir)
        {
            case direction.LEFT:
                {
                    transform.Rotate(0.0f, -speed * Time.deltaTime, 0.0f);
                    break;
                }
            case direction.RIGHT:
                {
                    transform.Rotate(0.0f, speed * Time.deltaTime, 0.0f);
                    break;
                }
        }
    }
}
