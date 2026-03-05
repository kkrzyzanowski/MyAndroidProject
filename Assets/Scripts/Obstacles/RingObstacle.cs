using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingObstacle : Obstacle {
 
    public enum Axis
    {
        HORIZONTAL, VERTICAL
    }
    public Axis axis;
	// Use this for initialization
	void Start () {
        SetDirection();
        SetSpeed();
	}
	
	// Update is called once per frame
	void Update () {
        movingObstacle();
	}
    protected override void movingObstacle()
    {

        //base.movingObstacle();
        switch (dir)
        {
            
            case direction.LEFT:
                {
                    if(axis == Axis.VERTICAL)
                        transform.Rotate(Vector3.up * -speed * Time.deltaTime, Space.World);
                    else if(axis == Axis.HORIZONTAL)
                        transform.Rotate(Vector3.forward * -speed * Time.deltaTime, Space.World);
                    break;
                }
            case direction.RIGHT:
                {
                    if (axis == Axis.VERTICAL)
                        transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
                    else if (axis == Axis.HORIZONTAL)
                        transform.Rotate(Vector3.forward * speed * Time.deltaTime, Space.World);
                    break;
                }
        }
       
    }
    void SetSpeed()
    {
        speed = Random.Range(10, 41);
    }
}
