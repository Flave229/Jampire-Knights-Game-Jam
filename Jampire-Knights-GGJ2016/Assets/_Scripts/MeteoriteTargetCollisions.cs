using UnityEngine;
using System.Collections;

public class MeteoriteTargetCollisions : MonoBehaviour {

    bool playerInTarget;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerInTarget = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerInTarget = false;
        }
    }

	// Use this for initialization
	void Start () {
        playerInTarget = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    public bool isPlayerInTarget()
    {
        return playerInTarget;
    }
}
