using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Purse : MonoBehaviour
{
    public static int money;
    public Text moneyText;
    
    // Start is called before the first frame update
    void Start()
    {
        money = 0;
        //moneyText.text = "" + money;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "" + money;
    }

    /*
    public void AddMoney(int c)
    {
        money += c;
    }
    */
}
