using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTwo : StageTrigger {

    private BulletObstacle bullet; 
   public float LeftStartShot;
    public float RightStartShot;
    private Vector3  startBullet;
    bool shoted;
   public  bool changeDir;
    public float time = 1f;
    BulletDirection dir;
    List<BulletObstacle> listBulletObstacle;
    public enum BulletDirection
    {
        LEFT, RIGHT
    }
    private void Update()
    {
        StartCoroutine(OnBulletShot());
    }
    protected override void Start()
    {
        base.Start();
        score = 30;
        SetBulletDirection();
    }
   
    IEnumerator OnBulletShot()
    {
        if (shoted == false)
        {
            bullet = Instantiate(obstacle, startBullet, Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f))) as BulletObstacle;
            bullet.MirrorSpeed(changeDir);
            bullet.transform.SetParent(this.transform, true);
            shoted = true;
            yield return new WaitForSeconds(time);
            shoted = false;
           
        }
    }   
    void SetBulletDirection()
    {
        dir = (BulletDirection)Random.Range(0, 2);
        if(dir == BulletDirection.LEFT)
        {
            startBullet = new Vector3(gameObject.transform.position.x -gameObject.GetComponent<Collider>().bounds.size.x/2 -1, 0.0f, gameObject.transform.position.z);
            changeDir = false;
        }
        else if( dir == BulletDirection.RIGHT)
        {
            startBullet = new Vector3(gameObject.transform.position.x + gameObject.GetComponent<Collider>().bounds.size.x/2 + 1, 0.0f, gameObject.transform.position.z);
            changeDir = true;
           // Bullet.MirrorSpeed(true);
        }
        shoted = false;
    }
    private void OnTriggerExit(Collider other)
    {
       
        if (other.tag == "Obstacle")
            Destroy(other.gameObject);
        if (other.CompareTag("Player"))
        {
            GameController.AddScore(score);
            StartCoroutine(DestroyBox(10f));
        }
    }
    public override void AddStage()
    {
        base.AddStage();
       
    }
}
