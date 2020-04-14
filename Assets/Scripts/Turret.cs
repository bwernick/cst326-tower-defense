using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCooldown = 0f;

    [Header("Setup Fields")]
    public float turnSpeed = 10;
    public Transform PartToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null)
        {
            Vector3 dir2 = new Vector3(0, 0, 0);
            Quaternion rot2 = Quaternion.LookRotation(dir2);
            // slerp to the desired rotation over time
            PartToRotate.rotation = Quaternion.Lerp(PartToRotate.rotation, rot2, turnSpeed * Time.deltaTime);
            //PartToRotate.LookAt(new Vector3(0, 0, 0));
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        // slerp to the desired rotation over time
        PartToRotate.rotation = Quaternion.Lerp(PartToRotate.rotation, rot, turnSpeed * Time.deltaTime);
        //PartToRotate.LookAt(new Vector3(target.position.x, PartToRotate.position.y, target.position.z));

        if(fireCooldown <= 0)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }

        fireCooldown -= Time.deltaTime;
    }

    //fancy sphere
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot()
    {
        GameObject bulletTemp = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletTemp.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        //stay locked on
        if (target != null && Vector3.Distance(transform.position, target.position) <= range)
        {
            return;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        //reaquire/lose target
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
}
