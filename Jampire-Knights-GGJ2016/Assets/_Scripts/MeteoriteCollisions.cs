using UnityEngine;
using System.Collections;

public class MeteoriteCollisions : MonoBehaviour {

    [HideInInspector]
    public GameObject target;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == target)
        {
            //print("Collision Happened Here Between" + gameObject.tag + " and " + col.gameObject.tag);

            target.GetComponent<MeteoriteTargetCollisions>().DealDamage();

            Destroy(target);
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
