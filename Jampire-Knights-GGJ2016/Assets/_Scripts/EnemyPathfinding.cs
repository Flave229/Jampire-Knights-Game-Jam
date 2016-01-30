using UnityEngine;
using System.Collections;

public class EnemyPathfinding : MonoBehaviour {

    public float enemyRange;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        GameObject nearestTower = FindClosestTower();
        Vector3 targetPos = new Vector3(0.0f, 0.0f, 0.0f);

        if (nearestTower != null)
        {
            // A tower has been detected, and therefore enemy prioritises attack
            targetPos = new Vector3(nearestTower.transform.position.x, 0.0f, nearestTower.transform.position.z);
        }
        else
        {
            nearestTower = FindObelisk();
            targetPos = new Vector3(nearestTower.transform.position.x, 0.0f, nearestTower.transform.position.z);
        }

        gameObject.GetComponent<Enemy>().setTargetPos(targetPos);
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
            float currDistance = distance.sqrMagnitude;

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
