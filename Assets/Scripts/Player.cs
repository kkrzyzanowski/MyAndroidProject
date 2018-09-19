using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private static Player instance = null;

    public ParticleSystem LineTrail;

    public float speed = 10f;
    public bool moving;
    bool IsGameOver;
    float distance = 0.0f;
    float movementvalue = 0.25f;
    int lives = 3;
    bool touchActive;
    bool TrailActive;
    Vector3 yourMovement;
    Rigidbody rb;
    //float time = 0.0f;
     public float minMovement = 0.5f;

    public static Player Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new Player();
            }
            return instance;
        }

      
    }
    
    private void Awake()
    {
        IsGameOver = false;
        instance = this;
    }
    // Use this for initialization
    void Start ()
    {
       
        speed = 10.0f;
        moving = true;
        touchActive = false;
        TrailActive = false;
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetButtonDown("Move"))
        {
            TrailActive = true;
            MoveTrail();
        }
        else if (Input.GetButton("Move"))
        {

            distance += movementvalue;
            //time = 0.0f;
            MovePlayer();
            TrailActive = true;
        }

        else if (Input.GetButtonUp("Move"))
        {
            TrailActive = false;
            MoveTrail();
        }

#elif UNITY_ANDROID
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Moved)
            {
                Vector2 deltaPos = Input.GetTouch(0).deltaPosition;
                if ((deltaPos.y >= 0.3 && deltaPos.x < 0.3))
                {
                    touchActive = true;
                    distance += movementvalue;
                    MovePlayer();
                }
            }

         else   if (t.phase == TouchPhase.Stationary)
            {
                if (touchActive)
                {
                    distance += movementvalue;
                    MovePlayer();
                }
            }
            else
                touchActive = false;
        }
#endif


        }
    void MovePlayer()
    {
        if (moving)
        { 
            Vector3 zPosChanged = new Vector3(transform.position.x, transform.position.y, transform.position.z + distance);
            transform.position = Vector3.Lerp(transform.position, zPosChanged, speed * Time.deltaTime);
            distance = 0;
           
    }
       
    }
   public void MoveTo(Vector3 targetPos)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Obstacle"))
        {
            SetGameOverStatus(true);
           // moving = false;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void SetGameOverStatus(bool isGameOver)
    {
        IsGameOver = isGameOver;
    }
    public bool GetGameOverStatus()
    {
        return IsGameOver;
    }
    void MoveTrail()
    {
        if (TrailActive)
            LineTrail.Play();
        else
            LineTrail.Stop();
    }   

}

