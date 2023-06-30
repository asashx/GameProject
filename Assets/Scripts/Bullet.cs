using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;

    public float speed = 20;

    public GameObject explosionEffectPrefab;
   
    private Transform target;

    private float distanceArriveTarget = 1.2f;
    public void SetTarget(Transform _target)
    {
        this.target = _target;  
    }

    void Update()
    {
         if(target == null)//如果目标不存在了,飞行中的子弹自行销毁
        {
            Die();
            return;
        }
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward*speed*Time.deltaTime);

        Vector3 dir=target.position - transform.position;
        if(dir.magnitude< distanceArriveTarget)
        {

            target.GetComponent<EnemybBlood>().TakeDamage(damage);
            GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);//增加特效
        Destroy(effect, 1);
        Destroy(this.gameObject);//销毁这个游戏物体,如果只是this，只是销毁Bullet组件
    }
}

