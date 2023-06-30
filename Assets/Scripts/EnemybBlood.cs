using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemybBlood : MonoBehaviour
{
    public GameObject explosionEffect;//爆炸特效
    public Slider slider;
    [SerializeField] private Gradient gradient;
    public Image HP;
    public int hp = 100;  // 怪物的最大血量
  
    void Start()
    {
        SetMaxHP(hp);
    }
    public void SetHP(int currentHP)
    {
        slider.value = currentHP;
        
        HP.color = gradient.Evaluate(slider.normalizedValue);
        
    }

    public void SetMaxHP(int maxHP)
    {
        slider.maxValue = maxHP;
        slider.value = maxHP;
        
        
    }

    public void TakeDamage(int damage)
    {
        if(hp<=0) return;
        hp -= damage;  // 减少当前血量
        SetHP(hp);
        if (hp <= 0)
        {
            Die();  // 怪物死亡逻辑
        }
        else
        {
            
            // 受到伤害逻辑
        }

    }


    //怪物死亡时调用changemoney加金币
    
    
    
    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effect, 1.5f);
        Destroy(this.gameObject);
    }
}
