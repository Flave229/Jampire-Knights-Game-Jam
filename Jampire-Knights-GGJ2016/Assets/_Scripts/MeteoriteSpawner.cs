using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeteoriteSpawner : MonoBehaviour {

    public Transform meteorPrefab;
    public Transform meteorTarget;

    public float defaultTimer;
    float timer;

	// Use this for initialization
	void Start () {
        timer = defaultTimer;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            InstantiateMeteor();
            timer = defaultTimer;
        }
	}

    void InstantiateMeteor()
    {
        Vector3 target;
        float r = Random.value;
        if (r <= 0.5)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            target = player.transform.position;
        }
        else if (r <= 0.75)
        {
            List<GameObject> targets = new List<GameObject>();
            targets.AddRange(GameObject.FindGameObjectsWithTag("Tower"));
            if (targets.Count == 0)
            {
                target = Random.insideUnitSphere;
                target.y = 0;
                target.Normalize();
                target *= 15;
            }
            else
            {
                target = targets[Random.Range(0, targets.Count)].transform.position;
            }
        }
        else
        {
            target = Random.insideUnitSphere;
            target.y = 0;
            target.Normalize();
            target *= 25;
        }

        Transform mTarget = (Transform)Instantiate(meteorTarget);
        mTarget.position = new Vector3(target.x, 0.05f, target.z);
        Transform meteor = (Transform)Instantiate(meteorPrefab);
        meteor.position = new Vector3(target.x, 20.0f, target.z) + new Vector3(Random.value, 0, Random.value) * 4;
        meteor.gameObject.GetComponent<MeteoriteCollisions>().target = mTarget.gameObject;
        meteor.gameObject.GetComponent<MeteoriteCTRL>().target = mTarget.gameObject;
    }
}
