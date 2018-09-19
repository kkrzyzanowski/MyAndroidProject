using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerObstacle : Obstacle {
    Animation anim;
    Animator animator;
    // Use this for initialization
    private void Awake()
    {
        SetDirection();
        anim = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        movingObstacle();
       
    }
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void movingObstacle()
    {
        base.movingObstacle();
        switch(dir)
        {
            case direction.LEFT:
                {
                    Debug.Log("LEFT");
                    animator.SetTrigger("NotReverse");
                    break;
                }
            case direction.RIGHT:
                {
                    Debug.Log("RIGHT");
                    animator.SetTrigger("Reverse");

                    break;
                }
        }
    }
}
