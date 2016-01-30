using UnityEngine;
using System.Collections;

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
        // Find Player
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Transform meteor = (Transform)Instantiate(meteorPrefab);
        meteor.transform.position = new Vector3(player.transform.position.x, 20.0f, player.transform.position.z);

        Transform target = (Transform)Instantiate(meteorTarget);
        target.transform.position = new Vector3(player.transform.position.x, 0.05f, player.transform.position.z);


        //Transform enemy = (Transform)Instantiate(enemyPrefab);
        //enemy.parent = enemyOrigin;
        //enemy.localPosition = pos;
        //enemy.rotation = rot;
    }
}
