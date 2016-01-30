using UnityEngine;
using System.Collections;

public class MeteoriteSpawner : MonoBehaviour
{
	private int _numbertoSpawn;
	private float _timer;
	private float _timeTillNext;
	private bool _attackComplete;

    public Transform meteorPrefab;
    public Transform meteorTarget;

    public float defaultTimer;
    float timer;

	// Use this for initialization
	void Start () {
		_attackComplete = false;
        timer = defaultTimer;
	}
	
	// Update is called once per frame
	void Update () {

		if (_numbertoSpawn > 0)
		{
			timer -= Time.deltaTime;

			if (timer <= 0)
			{
				_numbertoSpawn -= 1;
				InstantiateMeteor();
				timer = defaultTimer;
			}
		}
		else
		{
			_attackComplete = true;
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

	public void SetAttackPattern(int numberOfenemies, float time)
	{
		_attackComplete = false;
		_numbertoSpawn = numberOfenemies;
		_timeTillNext = numberOfenemies / time;
	}

	public bool GetProgress()
	{
		return _attackComplete;
	}
}
