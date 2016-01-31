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
        // First 10 waves are predetermined
        waves.Add(new Wave(enemySpawner, meteoriteSpawner, attackPatternDelay)
            .AddAttackPattern(3, 0, 5)
            .AddAttackPattern(4, 0, 5)
            .AddAttackPattern(8, 0, 5)
            );
        // Second wave introduces meteors
        waves.Add(new Wave(enemySpawner, meteoriteSpawner, attackPatternDelay)
            .AddAttackPattern(4, 1, 5)
            .AddAttackPattern(8, 2, 5)
            .AddAttackPattern(8, 3, 5)
            );
        // Third wave increases the frequency of the meteors
        waves.Add(new Wave(enemySpawner, meteoriteSpawner, attackPatternDelay)
            .AddAttackPattern(8, 5, 6)
            .AddAttackPattern(12, 5, 5)
            .AddAttackPattern(12, 5, 5)
            );
        // Fourth wave forces the player to deal with a huge amount of enemies - defences need to be used more and more now
        waves.Add(new Wave(enemySpawner, meteoriteSpawner, attackPatternDelay)
            .AddAttackPattern(15, 8, 10)
            .AddAttackPattern(20, 8, 15)
            .AddAttackPattern(20, 8, 10)
            );
        // Fith wave enhances the previous wave by increasing speed
        waves.Add(new Wave(enemySpawner, meteoriteSpawner, attackPatternDelay)
            .AddAttackPattern(15, 8, 8)
            .AddAttackPattern(20, 8, 12)
            .AddAttackPattern(30, 8, 13)
            );
        // Sixth wave holds back a little on the players and focuses on meteorites
        waves.Add(new Wave(enemySpawner, meteoriteSpawner, attackPatternDelay)
            .AddAttackPattern(20, 10, 15)
            .AddAttackPattern(20, 15, 15)
            .AddAttackPattern(20, 20, 15)
            );
        // Seventh wave stops the meteor strikes and reapplies pressure with enemies
        waves.Add(new Wave(enemySpawner, meteoriteSpawner, attackPatternDelay)
            .AddAttackPattern(30, 0, 15)
            .AddAttackPattern(30, 0, 15)
            .AddAttackPattern(35, 0, 15)
            );
        // Eigth wave calms down and acts as a buffer before the final act
        waves.Add(new Wave(enemySpawner, meteoriteSpawner, attackPatternDelay)
            .AddAttackPattern(40, 10, 20)
            .AddAttackPattern(40, 10, 20)
            .AddAttackPattern(60, 10, 20)
            );
        // Ninth wave sends in increasingly hard waves
        waves.Add(new Wave(enemySpawner, meteoriteSpawner, attackPatternDelay)
            .AddAttackPattern(100, 5, 45)
            .AddAttackPattern(120, 10, 50)
            .AddAttackPattern(150, 15, 55)
            );
        // Tenth is the boss battle!
        waves.Add(new Wave(enemySpawner, meteoriteSpawner, attackPatternDelay)
            .AddAttackPattern(2500, 300, 350)
            );
	}
	
	// Update is called once per frame
	void Update()
    {
        ToolTipMessage toolTip = GameObject.FindGameObjectWithTag("ToolTip").GetComponent<ToolTipMessage>();

        if (waves[_waveIndex].GetWaveComplete())
		{
            waves[_waveIndex]._waveActive = false;
            toolTip.setUIMessage("Wave " + (_waveIndex + 1).ToString() + " Complete!", 3.0f);
            Debug.Log("Wave " + (_waveIndex + 1).ToString() + " Complete");
            _waveIndex++;
		}

        if (_waveIndex == waves.Count)
        {
            waves.Add(new Wave(enemySpawner, meteoriteSpawner, attackPatternDelay)
                .AddAttackPattern(2500 + _waveIndex * _waveIndex, 200 + _waveIndex * 10, 350)
                .AddAttackPattern(0, 10, 10)
            );
        }

        if (waves[_waveIndex]._waveActive != true)
		{
            waves[_waveIndex]._waveActive = true;
            //toolTip.setUIMessage("Wave " + (_waveIndex + 1).ToString() + " Active", 3.0f);
			Debug.Log ("Wave " + (_waveIndex + 1).ToString() + " Active");

            // Special Cases for first few waves
            if (_waveIndex == 0)
            {
                toolTip.setUIMessage("Defend the Ritualistic Obelisk from God's wrath!", 5.0f);
            }
            else if (_waveIndex == 1)
            {
                toolTip.setUIMessage("Right click to spend points to build defences", 5.0f);
            }
		}

        waves[_waveIndex].update();
	}
}
