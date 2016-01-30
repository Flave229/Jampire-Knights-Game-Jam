using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {
	private Wave[] _waveArr = new Wave[2];
	private int _waveIndex = 0;

	public float waveDelay;
	public float attackPatternDelay;
	public EnemySpawner enemySpawner;
	public MeteoriteSpawner meteoriteSpawner;

	// Use this for initialization
	void Awake ()
	{
		for(int i = 0; i < _waveArr.Length; i++)
		{
			_waveArr [i] = new Wave (enemySpawner, meteoriteSpawner, attackPatternDelay);
		}
		_waveArr [0].AddAttackPattern (3, 0, 5);
		_waveArr [0].AddAttackPattern (4, 0, 5);
		_waveArr [0].AddAttackPattern (8, 0, 5);

		_waveArr [1].AddAttackPattern (0, 3, 9);
		_waveArr [1].AddAttackPattern (4, 0, 3);
		_waveArr [1].AddAttackPattern (7, 20, 40);

		Debug.Log ("Wave Manager Awake");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_waveArr [_waveIndex].GetWaveComplete ())
		{
			_waveArr [_waveIndex]._waveActive = false;
			_waveIndex = (_waveIndex + 1) % _waveArr.Length;
			Debug.Log ("Wave Complete");
		}

		if(_waveArr[_waveIndex]._waveActive != true)
		{
			_waveArr [_waveIndex]._waveActive = true;
			Debug.Log ("Wave Active");
		}

		_waveArr [_waveIndex].update ();
	}
}
