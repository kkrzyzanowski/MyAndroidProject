using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStage : StageTrigger {

    // Use this for initialization
    Vector3 centerBox;
protected override void Start () {
        centerBox = new Vector3(
            GetComponent<Collider>().bounds.size.x / 2,
             GetComponent<Collider>().bounds.size.y/ 2,
              GetComponent<Collider>().bounds.size.z / 2);
        boxSize = GetComponent<Collider>().bounds.size.z;
        score = 20;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void AddStage()
    {
     Obstacle obs =   Instantiate(obstacle, transform.position + centerBox, Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
        obs.transform.SetParent(this.transform, true);
    }
    private void OnTriggerExit(Collider other)
    {
        GameController.AddScore(score);
        StartCoroutine(DestroyBox(10f));
    }
}
