using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	private int _numbertoSpawn;
	private float _timer;
	private float _timeTillNext;
	private bool _attackComplete;

    public Transform enemyPrefab;
    public Transform enemyOrigin;
    public float radius;

    

	void Start()
    {
		_attackComplete = false;
		_numbertoSpawn = 0;
        _timer = 0;
	}
	
	void Update()
    {
		if (_numbertoSpawn > 0)
		{
			_timer += Time.deltaTime;

			if (_timer > _timeTillNext)
			{
				_numbertoSpawn -= 1;
				_timer = 0;

				Vector3 pos = Random.onUnitSphere;
				pos.y = 0;
				pos.Normalize ();
				pos *= radius;//on unit circle in xz plane with radius
				Quaternion rot = Quaternion.LookRotation (-pos);//look towards the center when spawned, not important when enemy class controls rotation
				Transform enemy = (Transform)Instantiate (enemyPrefab);
				enemy.parent = enemyOrigin;
				enemy.localPosition = pos;
				enemy.rotation = rot;
			}
		}
		else
		{
			_attackComplete = true;
		}

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
