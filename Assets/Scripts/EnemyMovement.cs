using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject start;
    public GameObject goal;
    
    // Start is called before the first frame update
    void Start()
    {
        //starting position
        this.transform.position = start.transform.position;
        //use the nav mesh to navigate to the goal
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
