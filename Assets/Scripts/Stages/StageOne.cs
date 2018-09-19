using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOne : StageTrigger
{
    private void Awake()
    {
        score = 10;
        boxSize = GetComponent<Collider>().bounds.size.z;
    }
    // Update is called once per frame
    void Update () {
		
	}

    public override void AddStage()
    {      
          playerTargetposition += boxSize;
            Vector3 newObstaclePos = new Vector3(0.0f, 0.0f, transform.position.z);
            InstatiateObstacle(newObstaclePos);
        
        
    }
   void InstatiateObstacle(Vector3 obstaclePos)
    {
       Obstacle obs = Instantiate(obstacle, obstaclePos, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        obs.transform.SetParent(this.transform, true);
       
    }
    private void OnTriggerExit(Collider other)
    {
        GameController.AddScore(score);
        StartCoroutine(DestroyBox(10f));
    }
}
