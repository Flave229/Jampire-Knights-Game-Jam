using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCTRL : MonoBehaviour {
	
	private int _scoreDisp;
	private static float _scoreReal;

	public Text _scoreText;

	// Use this for initialization
	void Start () {
		_scoreDisp = 0;
		_scoreReal = 0;
		_scoreText.text = "Score: 000";
	}
	
	// Update is called once per frame
	void Update () {
		_scoreReal += Time.deltaTime;
		_scoreDisp = (int) (_scoreReal + 0.5f);// always rounds up ame as maths.ceal()
		_scoreText.text = "Score: " + (_scoreDisp.ToString().PadLeft(5, '0'));
	}

    public static void addScore(int s)
    {
        _scoreReal += s;
    }
}
