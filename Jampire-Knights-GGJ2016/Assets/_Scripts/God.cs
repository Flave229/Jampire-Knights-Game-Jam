using UnityEngine;
using System.Collections;

public class God : MonoBehaviour {

    public static int score;
    public static string message;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
