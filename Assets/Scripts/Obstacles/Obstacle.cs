using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour {

    public float time;
    public float speed;
    public float horizontalValue;
    protected direction dir;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        movingObstacle();
	}
    protected virtual void movingObstacle()
    {

    }
    public enum direction
    {
        LEFT, RIGHT, NOT_ACTIVE
    }
  protected virtual void SetDirection()
    {
        dir = (direction)Random.Range(0, 2);
    }
    protected IEnumerator StartDestroying()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

}
