using UnityEngine;
using System.Collections;

public class ObeliskSCR : MonoBehaviour
{
    Health healthManager;

	void Start()
    {
        healthManager = GetComponent<Health>();
	}
	
	void Update()
    {
	    if (healthManager.health <= 0)
        {
            //Destroy(gameObject);
            God.score = ScoreCTRL.getScore();
            God.message = "The Obelisk fell to the Angels";
            Application.LoadLevel(2);
        }
	}
}
