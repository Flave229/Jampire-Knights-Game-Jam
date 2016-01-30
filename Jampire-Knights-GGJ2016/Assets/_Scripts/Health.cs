using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float maxHealth;
    public float health;

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void addHealth(float h)
    {
        if (health + h > 0)
        {
            if (health + h < maxHealth)
            {
                health += h;
            }
            else
            {
                health = maxHealth;
            }
        }
        else
        {
            health = 0;
        }
    }
}
