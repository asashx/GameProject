using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class BuildManager : MonoBehaviour
{
    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;
    private TurretData selectedTurretData;

    public TextMeshProUGUI moneyText;
    public Animator moneyAnimator;

    private int money = 100;

    void ChangeMoney(int change=0)
    {
        money += change;
        moneyText.text = "$"+money;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(EventSystem.current.IsPointerOverGameObject()==false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray,out hit, 1000, LayerMask.GetMask("MapCube"));
                if(isCollider)
                {
                    MapCube mapCube= hit.collider.GetComponent<MapCube>();
                    if(mapCube.turretGo==null)
                    {
                        if(money>selectedTurretData.cost-1)
                        {
                            ChangeMoney(-selectedTurretData.cost);
                            mapCube.BuildTurret(selectedTurretData.turretPrefab);
                        }
                        else
                        {
                            moneyAnimator.SetTrigger("flicker");
                        }
                    }
                    else
                    {
                        //TODO 升级处理
                    }
                }
            }
        }
    }
    public void OnLaserSelected(bool isOn)
    {
        if(isOn)
        {
            selectedTurretData = laserTurretData;
        }
    }
    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;
        }
    }
    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData =standardTurretData;
        }
    }
}
