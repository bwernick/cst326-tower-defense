using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public Transform currentDestination;
  private int currentIndexWaypoint = 0;
  public float speed = 1;

  public void Start()
  {
        this.transform.position = WaypointManager.waypoints[0].position;
        currentDestination = WaypointManager.waypoints[1];
        //GetNextWaypoint();
        //transform.position = currentDestination.transform.position; // Move to WP0
        //GetNextWaypoint();
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
