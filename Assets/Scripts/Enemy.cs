using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform currentDestination;
    private int currentIndexWaypoint = 0;
    public float speed = 1;
    public float startHealth = 100;
    private float health;
    public int value = 50;
    public Image healthBar;

  public void Start()
  {
        //this.transform.position = WaypointManager.waypoints[0].position;
        //probably the most pointless addition to this project
        //NavMeshAgent agent = GetComponent<NavMeshAgent>();
        //agent.destination = currentDestination.position;
        health = startHealth;
        currentDestination = WaypointManager.waypoints[1];
        //GetNextWaypoint();
        //transform.position = currentDestination.transform.position; // Move to WP0
        //GetNextWaypoint();
  }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if(health <= 0)
        {
            Purse.money += value;
            Destroy(gameObject);
        }
    }


  void Update()
  {
        Vector3 direction = currentDestination.transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (direction.magnitude < .2f)
        {
            GetNextWaypoint();
        }
    }

  private void GetNextWaypoint()
  {
        currentIndexWaypoint++;

        //handle  index out of bounds for waypoints
        if(currentIndexWaypoint >= WaypointManager.waypoints.Length-1)
        {
            Destroy(gameObject);
        }   

        currentDestination = WaypointManager.waypoints[currentIndexWaypoint];
        
  }
}
