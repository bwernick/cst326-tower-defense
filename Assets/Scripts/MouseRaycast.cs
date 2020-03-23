using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycast : MonoBehaviour
{
    EnemyHealth enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log("Clicked " + hit.transform.name); // ensure you picked right object
                if(hit.collider.tag == "Enemy")
                {
                    enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                    enemyHealth.AddjustHealth(-2);

                }
            }
        }
    }
}
