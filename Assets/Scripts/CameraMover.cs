using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    private Camera cameraView;
    private float startMovingCamera;
    bool movedCamera;
	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
        cameraView = GetComponent<Camera>();
        startMovingCamera = cameraView.transform.position.z;
        movedCamera = false;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (player.transform.position.z > (startMovingCamera - cameraView.orthographicSize/2) && !movedCamera)
        {
            offset = transform.position - player.transform.position;
            movedCamera = true;
        }
        if(movedCamera)
        {
            transform.position = player.transform.position + offset;
        }
        
	}
}
