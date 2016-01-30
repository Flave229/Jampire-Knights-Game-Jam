using UnityEngine;
using System.Collections;

public class ObeliskSCR : MonoBehaviour
{
    Health healthManager;

	void Start()
    {
        healthManager = GetComponent<Health>();
	}
	
	void Update()
    {
	    if (healthManager.health <= 0)
        {

        }
	}
}
