using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    private List<Wave> waves = new List<Wave>();
	private int _waveIndex = 0;

	public float waveDelay;
	public float attackPatternDelay;
	public EnemySpawner enemySpawner;
	public MeteoriteSpawner meteoriteSpawner;

	// Use this for initialization
	void Awake ()
	{
        waves.Add(new Wave(enemySpawner, meteoriteSpawner, attackPatternDelay)
            .AddAttackPattern(3, 0, 5)
            .AddAttackPattern(4, 0, 5)
            .AddAttackPattern(8, 0, 5)
            );
        waves.Add(new Wave(enemySpawner, meteoriteSpawner, attackPatternDelay)
            .AddAttackPattern(0, 3, 9)
            .AddAttackPattern(4, 0, 3)
            .AddAttackPattern(7, 20, 10)
            );
	}
	
	// Update is called once per frame
	void Update()
	{
        if (waves[_waveIndex].GetWaveComplete())
		{
            waves[_waveIndex]._waveActive = false;
            Debug.Log("Wave " + _waveIndex.ToString() + " Complete");
            _waveIndex = (_waveIndex + 1) % waves.Count;
		}

        if (waves[_waveIndex]._waveActive != true)
		{
            waves[_waveIndex]._waveActive = true;
			Debug.Log ("Wave " + _waveIndex.ToString() + " Active");
		}

        waves[_waveIndex].update();
	}
}
