using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnesPull : Item{

    private bool pulling;
    private bool pulled;
    private bool CanPush;
    void PullPlayer()
    {
        if (pulling)
        {
            Player.MoveTo(childTransform.position);
            Debug.Log("Pull");
            if(Player.transform.position == childTransform.position)
            {
                pulling = false;
                CanPush = true;
                Player.moving = false;
            }
        }
    }
    void PushPlayer()
    {
        if(pulled)
        {
            
            Vector3 pos  = Player.transform.position;
            pos.x = 0.0f;
            
            Player.MoveTo(pos);
            Debug.Log("Push");
            if (Player.transform.position == pos)
            {
                pulled = false;
                CanPush = false;
                Player.moving = true;
            }
            

        }
    }
    public override void OnInputStart()
    {
        if (Stage != null)
        {
          
            if (Stage.CanActivateItem)
            {

                if (CanPush)
                {
                    pulled = true;
                }
                else
                    pulling = true;
            
               
            }
         
        }
    }
    public override void Start()
    {
        base.Start();
        pulling = false;
        pulled = false;
        CanPush = false;
    }
    void Update()
    {
        
      
    }
    private void FixedUpdate()
    {
        if (!CanPush)
            PullPlayer();
        else
            PushPlayer();
    }
}
