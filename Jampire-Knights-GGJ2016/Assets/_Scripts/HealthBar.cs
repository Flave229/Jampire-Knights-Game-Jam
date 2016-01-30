using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Health healthManager;
    Vector3 defaultScale;

	// Use this for initialization
	void Start () {
        healthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        defaultScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
        adjustHealthBar();
	}

    void adjustHealthBar()
    {
        if (healthManager.health > 0)
        {
            gameObject.transform.localScale = new Vector3(defaultScale.x * (healthManager.health / healthManager.maxHealth), defaultScale.y, defaultScale.z);
        }
    }
}
