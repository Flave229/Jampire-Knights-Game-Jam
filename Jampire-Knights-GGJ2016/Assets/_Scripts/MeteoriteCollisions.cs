using UnityEngine;
using System.Collections;

public class MeteoriteCollisions : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Target")
        {
            print("Collision Happened Here Between" + gameObject.tag + " and " + col.gameObject.tag);

            if ((col.GetComponent<MeteoriteTargetCollisions>().isPlayerInTarget()))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().addHealth(-40);
            }

            Destroy(col.gameObject);
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
