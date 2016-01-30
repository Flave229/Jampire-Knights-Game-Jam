using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyPathfinding : MonoBehaviour
{
    Enemy enemyScript;
    public float enemyRange;

	void Start()
    {
        enemyScript = GetComponent<Enemy>();
	}
	
    void Update()
    {
        GameObject nearestTower = FindClosestTower();

        if (nearestTower == null)
        {
            nearestTower = FindObelisk();
        }

        if (nearestTower != null)
        {
            enemyScript.setTarget(nearestTower.transform);
        }
        else
        {
            enemyScript.setTarget(gameObject.transform);
        }
	}

    GameObject FindClosestTower()
    {
        GameObject[] towerList;
        towerList = GameObject.FindGameObjectsWithTag("Tower");

        // Make closest null, so ANY first enemy found would be 'nearer'
        GameObject closestTower = null;
        float lookDistance = enemyRange;

        // Find nearest Enemy
        foreach (GameObject tower in towerList)
        {
            Vector3 distance = tower.transform.position - gameObject.transform.position;
            float currDistance = distance.magnitude;

            // Checks if distance is within the range of tower
            if (currDistance < lookDistance)
            {
                closestTower = tower;

                // This line eliminates any enemies that appear within the look range, but further than the closest enemy
                lookDistance = currDistance;
            }
        }

        return closestTower;
    }

    GameObject FindObelisk()
    {
        GameObject Obelisk;
        Obelisk = GameObject.FindGameObjectWithTag("Obelisk");

        return Obelisk;
    }
}
