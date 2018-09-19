using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{


    protected Player Player;
    protected Transform childTransform;
    private StageTrigger stage;
    public StageTrigger Stage
    {
        get
        {
            return stage;
        }

        set
        {
            stage = value;
        }
    }

    public virtual void Start()
    {
        Player = FindObjectOfType<Player>();
        childTransform = gameObject.transform.GetChild(0);
    }




    public virtual void OnInputStart()
    {
#if UNITY_STANDALONE
        //if (Input.GetMouseButton(0))
        //{
        //    InputCollider.ObjectCollider.CatchInput();
        //    //pulling = true;
        //}
#elif UNITY_ANDROID
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //pulling = true;
        }
#endif


    }
}
