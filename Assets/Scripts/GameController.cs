using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

    enum Stage
    {
        START, MAGNES, BULLET, ROTATOR, HYPNO, HAMMER, LAST
    }
   
    public float zMax;
    float zFar;
    float currentPlayerPos;
    float previousPlayerPos;
    bool isStarting;

   
    float lastInstantiateZPos;
    float diffPlayerStage;
    float actullyBoxSize;

    private static float points;
    public Obstacle obstacle;
   
    public StageTrigger [] Triggers;
    private StageTrigger stageTrigger;
    
    private Stage stage;
    public Text scoreText;
	// Use this for initialization
	void Start () {
        
        isStarting = true;
        stage = Stage.START;
        points = 0;
        zFar = Mathf.Abs(zMax) + Mathf.Abs(Player.Instance.transform.position.z);
        currentPlayerPos = Player.Instance.transform.position.z;
        previousPlayerPos = currentPlayerPos;
        scoreText.text = "Score: " + points.ToString();
        StartGame();
    }
	
	// Update is called once per frame
	void Update () {

        UpdateGame();
        UpdateTextScore();
	}

    public static void AddScore (int score)
    {
        points += score;
        
    }
    void UpdateTextScore()
    {
        scoreText.text = "Score: " + points.ToString();
    }
    public static float GetScore()
    {
        return points;
    }
    void SetRangeStage(Stage s)
    {
        stage = (Stage)Random.Range(0, (int)s + 1);
    }
    void InstantiateStage(float zPos)
    {
        stageTrigger = Instantiate(Triggers[(int)stage], new Vector3(0.0f, 0.0f, zPos), Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
        stageTrigger.AddStage();
        lastInstantiateZPos = zPos;
        diffPlayerStage = zPos - currentPlayerPos;
        //Debug.Log("Ostatnia instancjonowana pozycja " + lastInstantiateZPos);
       // Debug.Log("Różnica pozycji palyer-lastInstance" + diffPlayerStage);
    }
    void StartGame()
    {
        stageTrigger = Triggers[(int)stage];
        actullyBoxSize = Triggers[(int)stage].boxSize;
        for(float i = Player.Instance.transform.position.z + stageTrigger.boxSize; i<zMax; i++)
        {
            InstantiateStage(i);
        }
        isStarting = false;
    }
    void ChoseStage()
    {
       if(points > 100 && points <= 200)
        {
            SetRangeStage(Stage.MAGNES);
        }
       else if(points > 200 && points <= 350)
        {
            SetRangeStage(Stage.BULLET);
        }
       else if(points > 350 && points <= 550)
        {
            SetRangeStage(Stage.ROTATOR);
        }
        else if (points > 550 && points <= 700)
        { 
            SetRangeStage(Stage.HYPNO);
        }
        else if (points > 700)
        {
            SetRangeStage(Stage.HAMMER);
        }
    }
    void CheckRange()
    {
        currentPlayerPos = Player.Instance.transform.position.z;
        if (currentPlayerPos >= previousPlayerPos + actullyBoxSize)
        {
            actullyBoxSize = Triggers[(int)stage].boxSize;
            InstantiateStage(currentPlayerPos+ zFar+ actullyBoxSize/2);
            previousPlayerPos = currentPlayerPos;
        }
    }
    void UpdateGame()
    {
        ChoseStage();
        CheckRange();
    }
}
