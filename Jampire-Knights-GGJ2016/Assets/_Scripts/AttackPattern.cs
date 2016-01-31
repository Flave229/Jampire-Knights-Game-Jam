using UnityEngine;
using System.Collections;

public class AttackPattern {
	public int _numberOfEnemies{ get; set;}
	public int _numberOfMeteorites{ get; set;}
	public float _time{ get; set;}

	public AttackPattern(int enemies, int meteorites, float duration){
		//Debug.Log ("E: " + enemies + " - M: " + meteorites + " - T: " + duration);

		_numberOfEnemies = enemies;
		_numberOfMeteorites = meteorites;
		_time = duration;
	}
}
