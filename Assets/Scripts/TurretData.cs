using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretData
{
    public GameObject turretPrefab;
    public int cost;
    public int costUpgraded;
    public TurretType type;
}
public enum TurretType
{
    LaserTurret,
    MissileTurret,
    StandardTurret
}
