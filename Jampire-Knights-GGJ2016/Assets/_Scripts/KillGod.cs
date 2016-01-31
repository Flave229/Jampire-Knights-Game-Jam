using UnityEngine;
using System.Collections;

public class KillGod : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RemoveGod()
    {
        Destroy(GameObject.Find("God"));
    }
}
