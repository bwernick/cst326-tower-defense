using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    public static int health;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health + "";
    }
}
