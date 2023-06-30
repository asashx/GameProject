using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveA : MonoBehaviour
{
    Transform target;
    public float speed = 20f;
    private int pointIndex = 0;
    private float rotateSpeed = 5f;
    private GameLives gameLives;
    
    // Start is called before the first frame update
    void Start()
    {
        target = RouteAPoints.positions[0];
        gameLives = FindObjectOfType<GameLives>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveA();
    }

    void MoveA(){
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        //敌人通过路径点时旋转
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        // 插值旋转，使物体平滑转向目标方向
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            pointIndex++;
            //到达终点
            if(pointIndex >= RouteAPoints.positions.Length)
            {
                return;
            }
            target = RouteAPoints.positions[pointIndex];
        }

        //判断是否抵达终点
        if(pointIndex >= RouteAPoints.positions.Length)
        {
            reachEnd();
        }

    }
    
    void reachEnd(){
        gameLives.DecreaseLives();
        GameObject.Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
    }
    public void TakeDamage(int damage)
    {

    }
}

