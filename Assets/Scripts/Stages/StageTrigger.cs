using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StageTrigger : MonoBehaviour {

    protected int score;
    protected bool CanBeDrawed;
    public Obstacle obstacle;
    protected float playerTargetposition;
    public float boxSize;
    [HideInInspector]
    public bool CanActivateItem;


   
    protected virtual float SetItemPosition()
    {
        float sizeBounds = GetComponent<Collider>().bounds.size.x;
        float position = Random.Range(-sizeBounds, sizeBounds);
        return position;
    }
    protected virtual bool SetProbability(float range)
    {
        float probability = Random.Range(0.0f, 1.0f);
        if (probability > range)
            CanBeDrawed = true;
        else
            CanBeDrawed = false;
        return CanBeDrawed;
    }
   protected  IEnumerator DestroyBox(float time)
    {
        bool canDestroy = false;
        playerTargetposition = Player.Instance.transform.position.z + boxSize;
        yield return new WaitForSeconds(time);
        canDestroy = true;
        if(canDestroy)
            Destroy(this.gameObject);
    }
    protected  virtual void Start()
    {
        CanBeDrawed = false;
        boxSize = GetComponent<Collider>().bounds.size.z;
        CanActivateItem = false;
    }
    protected virtual void AddObstacle()
    {

    }
    protected Vector3 getPlayerPos()
    {   
        return Player.Instance.gameObject.transform.position;
  
    }
    public virtual void AddStage()
    {

    } 
    protected void SetObstaclePos(Vector3 pos)
    {
        obstacle.transform.position = pos;
    }
  
}
