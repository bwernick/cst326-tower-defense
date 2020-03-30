using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject turretToBuild;

    public GameObject turret1Prefab;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one buildmanager");
            return;
        }

        instance = this;
    }

    void Start()
    {
        turretToBuild = turret1Prefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
