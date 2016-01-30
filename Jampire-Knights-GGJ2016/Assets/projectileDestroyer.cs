using UnityEngine;
using System.Collections;

public class projectileDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 1.5f);
	}
}
