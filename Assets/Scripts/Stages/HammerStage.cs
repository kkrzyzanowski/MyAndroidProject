using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerStage : StageTrigger {


	// Use this for initialization
	new void Start () {
        score = 40;
        AddObstacle();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    protected override void AddObstacle()
    {
        SetObstaclePos(new Vector3(SetItemPosition(), 0.0f, transform.position.z));
    }
    protected override float SetItemPosition()
    {
        if (Random.Range(0f, 1f) > 0.5)
        {
            return boxSize/4;
        }
        else
            return -boxSize/4;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
          //  CanActivateItem = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameController.AddScore(score);
        StartCoroutine(DestroyBox(10f));
    }
}
