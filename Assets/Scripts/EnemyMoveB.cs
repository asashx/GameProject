using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveB : MonoBehaviour
{
    Transform target;
    private float speed = 20f;
    private int pointIndex = 0;
    private float rotateSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        target = RouteBPoints.positions[0];
    }

    // Update is called once per frame
    void Update()
    {
        MoveB();
    }

    void MoveB(){
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
            if(pointIndex >= RouteBPoints.positions.Length)
            {
                return;
            }
            target = RouteBPoints.positions[pointIndex];
        }
            
        //判断是否抵达终点
        if(pointIndex >= RouteBPoints.positions.Length)
        {
            reachEnd();
        }

    }
    
    void reachEnd(){
        GameObject.Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
    }

}
