using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeteoriteSpawner : MonoBehaviour
{
	private int _numbertoSpawn;
	private float _timer;
	private float _timeTillNext;
	private bool _attackComplete;

    public Transform meteorPrefab;
    public Transform meteorTarget;

    float timer;

	// Use this for initialization
	void Start () {
		_attackComplete = false;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (_numbertoSpawn > 0)
		{
			timer += Time.deltaTime;

			while (timer >= _timeTillNext)
			{
				_numbertoSpawn -= 1;
				InstantiateMeteor();
				timer -= _timeTillNext;
			}
		}
		else
		{
			_attackComplete = true;
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
