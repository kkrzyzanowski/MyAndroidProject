using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBoost : Item {

    bool CanBoost;
    private void Awake()
    {
        Stage = GetComponentInParent<HammerStage>();
    }
    public override void Start () {
        CanBoost = false;
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void OnInputStart()
    {
        if(Stage != null && Stage.CanActivateItem)
        {
            CanBoost = true;
        }

    }
    void MovePlayerTowards()
    {
        if (CanBoost)
        {

            Player.speed *= 1.5f;
            Player.MoveTo(childTransform.position);
            Player.speed /= 1.5f;
            if (Player.transform.position == childTransform.position)
                CanBoost = false;
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Stage.CanActivateItem = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Stage.CanActivateItem = false ;
            //CanBoost = false;
        }
    }
    private void FixedUpdate()
    {
        MovePlayerTowards();
    }
}
