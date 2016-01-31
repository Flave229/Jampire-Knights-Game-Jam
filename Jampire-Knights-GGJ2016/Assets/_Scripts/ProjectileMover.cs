using UnityEngine;
using System.Collections;

public class ProjectileMover : MonoBehaviour
{
    public float speed;

	void Start()
    {
	
	}
	
	void Update()
    {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Enemy")){
            other.gameObject.GetComponent<Health>().health -= 10;
			//Destroy (other.gameObject, 0.1f);
			Destroy (gameObject);
		}
	}
}
