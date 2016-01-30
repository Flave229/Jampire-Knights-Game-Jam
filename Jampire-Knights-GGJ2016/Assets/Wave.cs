using UnityEngine;
using System.Collections;

public class Wave {
	//private ArrayList _wave;
	private AttackPattern[] _wave = new AttackPattern[10];
	private int _attackIndex = 0;
	private EnemySpawner _enemySpawner;
	private MeteoriteSpawner _meteoriteSpawner;
	private bool _waveComplete = false;

	private float _attackDelay = 0;
	private float _attackPatternDelay;
	private bool _sequenceRunning = false;

	public bool _waveActive { get; set;}

	public Wave(EnemySpawner eS, MeteoriteSpawner mS, float delay)
	{
		_enemySpawner = eS;
		_meteoriteSpawner = mS;
		_attackPatternDelay = delay;
		_waveActive = false;
	}

	void Start()
	{
		_attackIndex = 0;
	}

	public void update(){
		if (_attackIndex != _wave.Length)
		{
			if (_attackDelay < _attackPatternDelay)
				_attackDelay += Time.deltaTime;

			Debug.Log ("Checking for wave attack");
			Debug.Log (_attackDelay);

			if (_attackDelay <= _wave[_attackIndex]._time && _sequenceRunning == false)
			{
				Debug.Log ("Wave Attack Now!");
				Attack ();
				_sequenceRunning = true;
			}

			if (_attackDelay >= _wave[_attackIndex]._time) {
				if (_enemySpawner.GetProgress () && _meteoriteSpawner.GetProgress ()) {
					Debug.Log ("Wave Attack Complete!");
					_sequenceRunning = false;
					AttackPhaseComplete ();// increments the _attackIndex
					_attackDelay = 0.0f;
				}
			}
		}
		else
		{
			_waveComplete = true;
		}
	}

	public void Attack()
	{
		foreach (AttackPattern w in _wave) {
			Debug.Log (w);
		}
		if(_wave[_attackIndex]._numberOfEnemies > 0)
		{
			Debug.Log (_wave [_attackIndex]);
			Debug.Log (_enemySpawner);
			_enemySpawner.SetAttackPattern (_wave[_attackIndex]._numberOfEnemies, _wave[_attackIndex]._time);
		}
		if(_wave[_attackIndex]._numberOfMeteorites > 0)
		{
			_meteoriteSpawner.SetAttackPattern (_wave[_attackIndex]._numberOfMeteorites, _wave[_attackIndex]._time);
		}
	}

	public bool AddAttackPattern(int numOfEnemies, int numOfMeteors, float duration)
	{
		AttackPattern newPattern = new AttackPattern (numOfEnemies, numOfMeteors, duration);
		bool success = false;

		for (int i = 0; i < _wave.Length; i++)
		{
			if (_wave [i] == null) {
				_wave [i] = newPattern;
				success = true;
				break;
			}
		}

		return success;
	}

	public void AttackPhaseComplete()
	{
		if (_wave.Length > _attackIndex)
		{
			_attackIndex += 1;
		}
	}

	public bool GetWaveComplete()
	{
		return _waveComplete;
	}
}
