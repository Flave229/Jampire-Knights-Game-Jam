using UnityEngine;
using System.Collections;

public class ProjectileMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0.0f, 0.0f, 1.0f);
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Enemy")){
            other.gameObject.GetComponent<Health>().health -= 10;
			//Destroy (other.gameObject, 0.1f);
			Destroy (gameObject);
		}
	}
}
