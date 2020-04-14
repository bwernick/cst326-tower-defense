using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    public Button startButton;
    private Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(RestartScene);
    }

    void RestartScene()
    {
        //reset resources
        Purse.money = 50;
        TowerHealth.health = 3;

        //Destroy all enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }

        //Destroy all turrets
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("turret");
        foreach (GameObject turret in turrets)
        {
            GameObject.Destroy(turret);
        }

        startButton.interactable = true;
        btn.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

}
