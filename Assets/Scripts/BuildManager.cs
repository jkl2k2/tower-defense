using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [FormerlySerializedAs("anotherTurretPrefab")] public GameObject missileLauncherPrefab;

    private TurretBlueprint turretToBuild;
    
    public GameObject buildEffect;
    
    public bool CanBuild => turretToBuild != null;
    public bool HasMoney => PlayerStats.Money >= turretToBuild.cost;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);
        
        Debug.Log("Turret built! Money left: " + PlayerStats.Money);
    }
    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
