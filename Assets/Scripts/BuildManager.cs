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

    private MapCube selectedMapCube;

    public TextMeshProUGUI moneyText;
    public Animator moneyAnimator;

    public int money = 1000;

    public GameObject upgradeCanvas;

    public Button buttonUpgrade;

    public void ChangeMoney(int change=0)
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
                    if(selectedTurretData!=null&&mapCube.turretGo==null)
                    {
                        if(money>selectedTurretData.cost-1)
                        {
                            ChangeMoney(-selectedTurretData.cost);
                            mapCube.BuildTurret(selectedTurretData);
                        }
                        else
                        {
                            moneyAnimator.SetTrigger("flicker");
                        }
                    }
                    else if(mapCube.turretGo!=null)
                    {
                        //TODO 升级处理
                           // ShowUpgradeUI(mapCube.transform.position,mapCube.isUpgraded);
                        if(mapCube==selectedMapCube&&upgradeCanvas.activeInHierarchy)
                        {
                            HideUpgradeUI();
                        }
                        else
                        {
                            ShowUpgradeUI(mapCube.transform.position, mapCube.isUpgraded);
                        }
                        selectedMapCube=mapCube;
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
    void ShowUpgradeUI(Vector3 pos,bool isDisableUpgrade=false)
    {
        upgradeCanvas.SetActive(true);
        upgradeCanvas.transform.position = pos;
        buttonUpgrade.interactable =!isDisableUpgrade;
    }
   IEnumerator HideUpgradeUI()
    {
        upgradeCanvas.SetActive(false);
        yield return new WaitForSeconds(0.8f);
    }
    public void OnUpgradeButtonDown()
    {
        if(money>=selectedMapCube.turretData.costUpgraded)
        {
            ChangeMoney(-selectedMapCube.turretData.costUpgraded);
            selectedMapCube.UpgradeTurret();
        }
     else
        {
            moneyAnimator.SetTrigger("flicker");
        }
       StartCoroutine(HideUpgradeUI());
    }
    public void OnDestroyButtonDown()
    {
        selectedMapCube.DestroyTurret();
        StartCoroutine(HideUpgradeUI());
    }
}
