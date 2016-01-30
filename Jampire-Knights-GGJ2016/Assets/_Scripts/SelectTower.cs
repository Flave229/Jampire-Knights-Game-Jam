using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SelectTower : MonoBehaviour {

    List<string> uniqueTowers = new List<string>();
    public int currSelection;
    public float lastScroll;
    public Text displayedText;

	// Use this for initialization
	void Start () {
        currSelection = 0;
        lastScroll = 0.0f;

        displayedText.text = "No Tower Selected";
        uniqueTowers.Add("Tower");
        uniqueTowers.Add("Barricade");
	}
	
	// Update is called once per frame
	void Update () {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float scrollDiff = lastScroll - scroll;
        lastScroll = scroll;

        if (scrollDiff == 0.0f)
        {
            // Nothing
        }
        else if (scrollDiff > 0.0f)
        {
            currSelection++;

            // Scroll to the right of avaliable towers
            if (currSelection >= uniqueTowers.Count)
            {
                currSelection = uniqueTowers.Count - 1;
            }
        }
        else
        {
            currSelection--;
            // Scroll to the left avaliable towers
            if (currSelection < 0)
            {
                currSelection = 0;
            }
        }

        displayedText.text = getSelectedTower();
	}

    public string getSelectedTower()
    {
        return uniqueTowers[currSelection];
    }
}
