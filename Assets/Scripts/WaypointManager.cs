using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
  public static Transform[] waypoints;
    private int size;

  void Awake()
  {
        waypoints = new Transform[transform.childCount];
        for(int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }

    //waypoints = GetComponentsInChildren<Waypoint>();
        
    
  }

    /*
  public Waypoint GetNeWaypoint(int currentIndex)
  {
     return waypoints[currentIndex++];
  }
  */
}
