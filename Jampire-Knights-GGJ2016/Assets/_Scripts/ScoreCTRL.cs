using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCTRL : MonoBehaviour {
	
	private int _scoreDisp;
	private float _scoreReal;

	public Text _scoreText;

	// Use this for initialization
	void Start () {
		_scoreDisp = 0;
		_scoreReal = 0;
		_scoreText = "Score: 000";
	}
	
	// Update is called once per frame
	void Update () {
		_scoreDisp += Time.deltaTime;
		_scoreReal = (int) (_scoreReal + 0.5f);
		_scoreText = "Score: " + (_scoreDisp.ToString().PadLeft(5, '0'));
	}
}
