using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightObstacle : Obstacle {
   
    public float maxMovement;
    public float waitTime;
    public float delta;
    float startPosition;
   
    private itemSide side;

    public bool IsRun
    {
        get
        {
            return isRun;
        }

        set
        {
            isRun = value;
        }
    }
    public itemSide Side
    {
        get
        {
            return side;
        }

        set
        {
            side = value;
        }
    }
    bool isRun;
    // Use this for initialization
    void Start () {
        startPosition = transform.position.x;
        dir = direction.NOT_ACTIVE;
        IsRun = false;
        SetDirection();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

            ContinueRun();
            movingObstacle();
        
    }


    IEnumerator ChangeDirection()
    {
        

            yield return new WaitForSeconds(waitTime);
            switch (side)
            {
                case itemSide.LEFT_SIDE:
                    {
                        if (transform.position.x >= maxMovement)
                        {
                            dir = direction.LEFT;
                        }
                        if (transform.position.x < -maxMovement + delta)
                        {
                            dir = direction.RIGHT;
                        }
                        break;
                    }
                case itemSide.RIGHT_SIDE:
                    {
                        if (transform.position.x >= maxMovement - delta)
                        {
                            dir = direction.LEFT;
                        }
                        if (transform.position.x < -maxMovement)
                        {
                            dir = direction.RIGHT;
                        }
                        break;
                    }
                default:
                    break;


            }
        
    }
 

    
    
   protected override void movingObstacle()
    {
        switch (dir)
        {

            case direction.LEFT:
                {
                    transform.Translate(-speed * Time.deltaTime, 0.0F, 0.0F);
                    break;
                }
            case direction.RIGHT:
                {
                    transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
                    break;
                }
            case direction.NOT_ACTIVE:
                {
                   // transform.Translate(0.0f, 0.0f, 0.0f);
                    break;
                }
        }
    }
    void ContinueRun()
    {
        StartCoroutine("ChangeDirection");
    }
    protected  override void SetDirection()
    {
        base.SetDirection();
        isRun = true;
    }
    public enum itemSide
    {
        LEFT_SIDE, RIGHT_SIDE, NONE
    }
}
