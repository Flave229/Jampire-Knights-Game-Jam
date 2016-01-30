using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeteoriteTargetCollisions : MonoBehaviour {

    List<GameObject> inTarget = new List<GameObject>();

    void OnTriggerEnter(Collider col)
    {
        inTarget.Add(col.gameObject);
    }

    void OnTriggerExit(Collider col)
    {
        inTarget.Remove(col.gameObject);
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    public void DealDamage()
    {
        foreach (GameObject g in inTarget)
        {
            if (g)
            {
                Health h = g.GetComponent<Health>();
                if (h)
                {
                    h.addHealth(-40);
                }
            }
        }
    }
}
