using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public bool isDead;
    public int value;

    void Update()
    {
        AddjustHealth(0);
        if (isDead)
        {
            Purse.money += value;
            Destroy(gameObject);
        }
    }

    public void AddjustHealth(float adj)
    {
        health += adj;

        if (health <= 0)
        {
            health = 0;
            isDead = true;
        }
    }
}

