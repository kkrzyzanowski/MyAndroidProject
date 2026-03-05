using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureItems : MonoBehaviour {

	void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            InputCollider.ObjectCollider.CatchInput();
           
        }
#elif UNITY_ANDROID
       if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            InputCollider.ObjectCollider.CatchInput();
        }
#endif


    }
}

