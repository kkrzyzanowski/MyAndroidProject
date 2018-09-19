using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HypnoStage : StageTrigger {
    public Obstacle[] obstacles;
    Vector3 centerBox;
	// Use this for initialization
	new void Start () {
        centerBox = new Vector3(
            GetComponent<Collider>().bounds.size.x / 2,
             GetComponent<Collider>().bounds.size.y / 2,
              GetComponent<Collider>().bounds.size.z / 2);
        score = 30;
       // AddStage();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void AddStage()
    {
        //for(int i=0; i<obstacles.Length; i++)
        //{
        //    //Instantiate(obstacles[i], transform.position + centerBox, Quaternion.Euler(Vector3.zero));
            
        //}
    }
    private void OnTriggerExit(Collider other)
    {
        GameController.AddScore(score);
        StartCoroutine(DestroyBox(10f));
    }
}
