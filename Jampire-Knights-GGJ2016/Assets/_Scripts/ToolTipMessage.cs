using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ToolTipMessage : MonoBehaviour {

    private float timer = 0;
    private string s;
    private List<string> backlogMessages = new List<string>();
    private List<float> backlogTimes = new List<float>();
    public Text _tooltipText;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0;
                s = "";
            }
        }
        else if (backlogMessages.Count > 0)
        {
            setUIMessage(backlogMessages[0], backlogTimes[0]);

            backlogMessages.Remove(backlogMessages[0]);
            backlogTimes.Remove(backlogTimes[0]);
        }

        _tooltipText.text = s;
    }

    public void setUIMessage(string message, float time)
    {
        // Do not fire message if another is displayed
        if (timer == 0)
        {
            timer = time;
            s = message;
        }
        else
        {
            backlogMessages.Add(message);
            backlogTimes.Add(time);
        }
    }
}
