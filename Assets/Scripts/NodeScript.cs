using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public Color hoverColor;
    private Renderer rend;
    private Color startColor;

    private GameObject turret;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Cannot build here");
            return;
        }

        //Build turret;
        if(Purse.money < 15)
        {
            Debug.Log("Not enough money!");
            return;
        }
        else
        {
            Purse.money -= 15;
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
        }
        
    }
}
