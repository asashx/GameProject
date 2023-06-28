using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrret : MonoBehaviour
{
public List<GameObject> enemys=new List<GameObject>();
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
}
