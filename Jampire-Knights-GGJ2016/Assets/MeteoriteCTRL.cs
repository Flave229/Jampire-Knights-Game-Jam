using UnityEngine;
using System.Collections;

public class MeteoriteCTRL : MonoBehaviour {

	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = gameObject.transform.position;
        newPos.y -= 10.0f * Time.deltaTime;

        gameObject.transform.position = newPos;
	}

}
