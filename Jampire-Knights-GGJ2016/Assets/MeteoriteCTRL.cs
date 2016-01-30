using UnityEngine;
using System.Collections;

public class MeteoriteCTRL : MonoBehaviour {

    public float speed;
    [HideInInspector]
    public GameObject target;
	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate((target.transform.position - transform.position).normalized * speed * Time.deltaTime);
	}

}
