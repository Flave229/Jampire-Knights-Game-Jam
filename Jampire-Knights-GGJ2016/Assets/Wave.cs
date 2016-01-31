using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave {
	//private ArrayList _wave;
	private List<AttackPattern> waveParts = new List<AttackPattern>();
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
		if (_attackIndex != waveParts.Count)
		{
			//if (_attackDelay < _attackPatternDelay)
				_attackDelay += Time.deltaTime;

			if (_attackDelay <= waveParts[_attackIndex]._time && _sequenceRunning == false)
			{
				Attack ();
				_sequenceRunning = true;
			}

			if (_attackDelay >= waveParts[_attackIndex]._time) {
				if (_enemySpawner.GetProgress () && _meteoriteSpawner.GetProgress ()) {
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
		if(waveParts[_attackIndex]._numberOfEnemies > 0)
		{
            _enemySpawner.SetAttackPattern(waveParts[_attackIndex]._numberOfEnemies, waveParts[_attackIndex]._time);
		}
        if (waveParts[_attackIndex]._numberOfMeteorites > 0)
		{
            _meteoriteSpawner.SetAttackPattern(waveParts[_attackIndex]._numberOfMeteorites, waveParts[_attackIndex]._time);
		}
	}

	public Wave AddAttackPattern(int numOfEnemies, int numOfMeteors, float duration)
	{
		AttackPattern newPattern = new AttackPattern (numOfEnemies, numOfMeteors, duration);
        waveParts.Add(newPattern);
        return this;
	}

	public void AttackPhaseComplete()
	{
		if (_attackIndex < waveParts.Count)
		{
			_attackIndex += 1;
            if (_attackIndex == waveParts.Count)
            {
                _waveComplete = true;
            }
		}
	}

	public bool GetWaveComplete()
	{
		return _waveComplete;
	}
}
