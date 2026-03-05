using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : StageTrigger
{

    // Use this for initialization


    private bool instantiateManges;
    private LeftRightObstacle cloneLeftRightObstacle;
    public MagnesPull magnes;
    private MagnesPull cloneMagnes;
  
    protected override void Start()
    {

        base.Start();
        CanActivateItem = false;
        score = 30;
        instantiateManges = false;
        boxSize = GetComponent<Collider>().bounds.size.z;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            CanActivateItem = true;

        }
    }
      void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            GameController.AddScore(score);
            CanActivateItem = false;
            StartCoroutine(DestroyBox(10.0f));
        }
    }
    public override void AddStage()
    {
        
                float LRobstaclePos = SetItemPosition();
                cloneLeftRightObstacle = Instantiate(obstacle, new Vector3(LRobstaclePos, 0.0f, transform.position.z), Quaternion.Euler(0.0f, 0.0f, 0.0f)) as LeftRightObstacle;
                if (LRobstaclePos >= 0.0f)
                {
                    cloneMagnes = Instantiate(magnes, new Vector3(-4f, 0.0f, transform.position.z), Quaternion.Euler(0.0f, 180f, 0.0f)) as MagnesPull;
                    cloneLeftRightObstacle.Side = LeftRightObstacle.itemSide.LEFT_SIDE;

                }
                else
                {
                    cloneMagnes = Instantiate(magnes, new Vector3(4f, 0.0f, transform.position.z), Quaternion.Euler(180.0f, 0.0f, 0.0f)) as MagnesPull;
                    cloneLeftRightObstacle.Side = LeftRightObstacle.itemSide.RIGHT_SIDE;
                }
                if(cloneMagnes != null)
        {
            cloneMagnes.Stage = this;
            cloneMagnes.transform.SetParent(this.transform, true);
            cloneLeftRightObstacle.transform.SetParent(this.transform, true);
        }
               
      
    }
   
}


 
