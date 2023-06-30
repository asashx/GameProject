using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject turretGo;
    [HideInInspector]
    public TurretData turretData;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();   
    }
    public void BuildTurret(TurretData turretData)
    {
       this.turretData = turretData;
        isUpgraded = false;
        Vector3 turretPosition = transform.position + new Vector3(0f, 0.5f, 0f); // 添加向上的偏移量
        turretGo = GameObject.Instantiate(turretData.turretPrefab,turretPosition,Quaternion.identity);
    }

    public void UpgradeTurret()
    {
        if (isUpgraded == true) return;
        Destroy(turretGo);
        isUpgraded = true;
        turretGo = GameObject.Instantiate(turretData.turretUpgradedPrefab, transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity);
    }

    public void DestroyTurret()
    {
        Destroy(turretGo);
        isUpgraded=false;
        turretGo = null;
        turretData = null;
    }
     void OnMouseEnter()
    {
        if(turretGo==null&&!EventSystem.current.IsPointerOverGameObject())
        {
            renderer.material.color = Color.red;
        }
    }
    void OnMouseExit()
    {
        renderer.material.color = Color.white;    
    }
}
