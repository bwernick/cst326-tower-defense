using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycast : MonoBehaviour
{
    Enemy enemy;

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
                    enemy = hit.collider.GetComponent<Enemy>();
                    enemy.TakeDamage(20f);

                }
            }
        }
    }
}
