using UnityEngine;
using System.Collections;

public class TowerShoot : MonoBehaviour {

    Vector3 towerPos;
    public float towerRange;

    // Measured in Miliseconds
    public float fireDefaultCooldown;
    float fireCooldown;
    public float fireDamage;

    public Rigidbody projectile;
    public Transform projectileSpawnPoint;

	// Use this for initialization
    void Start()
    {
        towerPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        bool enemyInSight = false;
        GameObject nearestEnemy = FindClosestEnemy();

        if (nearestEnemy != null)
        {
            enemyInSight = true;
            Vector3 lockedYLookAt = new Vector3(nearestEnemy.transform.position.x, gameObject.transform.position.y, nearestEnemy.transform.position.z);
            transform.LookAt(lockedYLookAt);
        }

        // if tower is cooling down, take away time from the cooler
        if (fireCooldown > 0)
        {
            fireCooldown -= Time.deltaTime;

            if (fireCooldown < 0)
            {
                fireCooldown = 0;
            }
        }

        // If tower is able to fire, shoot projectile
        if (enemyInSight && fireCooldown == 0)
        {
            FireProjectile();

            fireCooldown = fireDefaultCooldown;
        }
	}

    GameObject FindClosestEnemy()
    {
        GameObject[] enemyList;
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");

        // Make closest null, so ANY first enemy found would be 'nearer'
        GameObject closestEnemy = null;
        float lookDistance = towerRange;

        // Find nearest Enemy
        foreach (GameObject enemy in enemyList)
        {
            Vector3 distance = enemy.transform.position - towerPos;
            float currDistance = distance.sqrMagnitude;

            // Checks if distance is within the range of tower
            if (currDistance < lookDistance)
            {
                closestEnemy = enemy;

                // This line eliminates any enemies that appear within the look range, but further than the closest enemy
                lookDistance = currDistance;
            }
        }

        return closestEnemy;
    }

    void FireProjectile()
    {
        Rigidbody projectileInstance;
        projectileInstance = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation) as Rigidbody;
    }
}
