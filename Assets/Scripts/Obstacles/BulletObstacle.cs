using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObstacle: Obstacle {

   
    protected override void movingObstacle()
    {
        base.movingObstacle();
        transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
    }
    private void Update()
    {
        movingObstacle();
       
      //  StartCoroutine(StartDestroying());
    }
    private void Awake()
    {
        time = 1f;
        speed = 6f;
    }
    
    public void MirrorSpeed(bool changeDir)
    {
        if (changeDir)
        {
            speed = -speed;
        }

    }
    private void OnTriggerExit(Collider other)
    {
       
        if(other.CompareTag("StageBox"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
    }
}
