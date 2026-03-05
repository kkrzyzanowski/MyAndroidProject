using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoving : Obstacle {

    float symetric;
    public float xMax, xMin;
   
	// Use this for initialization
	void Start () {
        horizontalValue = Random.Range(xMax, xMin);
        symetric = -horizontalValue;
        SetDirection();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        movingObstacle();
	}
    protected override void movingObstacle()
    {
        switch (dir)
        {
            case direction.LEFT:
                {
                    if (speed > 0.0f)
                        speed = -speed;
                    if (transform.position.x < symetric)
                        dir = direction.RIGHT;
                    break;
                }
            case direction.RIGHT:
                {
                    if (speed < 0.0f)
                        speed = -speed;
                    if (transform.position.x > horizontalValue)
                        dir = direction.LEFT;
                    break;
                }
        }
       
        transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
    }
}
