using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class Tower : MonoBehaviour
{
    Health healthManager;
    public int cost;

	void Start()
    {
        healthManager = GetComponent<Health>();
	}
	
	void Update()
    {
	    if (healthManager.health <= 0)
        {
            Destroy(gameObject);
        }
	}

    public int getCost()
    {
        return cost;
    }
}
