using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button restartBtn;
    public static bool levelStarted  = false;

    // Start is called before the first frame update
    void Start()
    {
        restartBtn.interactable = false;
        restartBtn.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if ((TowerHealth.health == 0 || enemies.Length == 0) && levelStarted)
        {
            restartBtn.gameObject.SetActive(true);
            restartBtn.interactable = true;
        }
    }
}
