using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScore : MonoBehaviour {

    Text _scoreText;

	// Use this for initialization
	void Start () {
        _scoreText = GetComponent<Text>();
        _scoreText.text = God.message + "      Score: " + God.score;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
