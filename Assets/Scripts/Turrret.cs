using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrret : MonoBehaviour
{
private List<GameObject> enemys=new List<GameObject>();
    void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Enemy")
        {
            enemys.Add(col.gameObject);
        }
    } 
    void OnTriggerExit(Collider col)
    {
        if(col.tag=="Enemy")
        {
            enemys.Remove(col.gameObject);
        }
    }
    public float attackRateTime=1;//�����빥��һ��
    private float timer = 0;

    public GameObject bulletPrefab;//�ӵ�
    public Transform firePosition;
    public Transform head;

    public bool useLaser=false;
    public float damageRate = 70;

    public LineRenderer laserRenderer;
    private void Start()
    {
        timer=attackRateTime;
    }
    void Update()
    {
        if (enemys.Count > 0 && enemys[0] != null)
        {
            Vector3 targetPosition = enemys[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }
        if (useLaser == false)
        {
            timer += Time.deltaTime;
            if (enemys.Count > 0 && timer >= attackRateTime)
            {
                timer = 0;
                Attack();
            }
        }
        else if(enemys.Count > 0)
        {
            if (laserRenderer.enabled == false)
                laserRenderer.enabled = true;
            if(enemys[0] == null)
            {
                UpdateEnemys();
            }
            if(enemys.Count>0)
            {
                laserRenderer.SetPositions(new Vector3[] { firePosition.position, enemys[0].transform.position });
                enemys[0].GetComponent<EnemybBlood>().TakeDamage(Mathf.RoundToInt(damageRate * Time.deltaTime));
            }
        }
        else
        {
            laserRenderer.enabled = false;
        }
        
    }
    void Attack()
    {
        if (enemys[0]==null)
        {
            UpdateEnemys();
        }
        if (enemys.Count > 0)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
        }
        else
        {
            timer = attackRateTime;
        }
    }

    void UpdateEnemys()
    {
       List<int>emptyIndex =new List<int>();
        for(int index=0;index<enemys.Count;index++)
        {
            if (enemys[index]==null)
            {
                emptyIndex.Add(index);
            }
        }

        for(int i=0;i<emptyIndex.Count;i++)
        {
            enemys.RemoveAt(emptyIndex[i] - i);
        }
    }
}
