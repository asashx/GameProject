using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;
    //表示当前选择的炮台（要建造的炮台）
   public TurretData selectedTurretData;
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
