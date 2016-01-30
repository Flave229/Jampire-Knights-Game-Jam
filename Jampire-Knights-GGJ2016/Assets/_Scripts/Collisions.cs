using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {

    public Health healthManager;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            PlayerLosesHealth();
        }
    }

    void PlayerLosesHealth()
    {
        healthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthManager.addHealth(-10.0f);
    }

    //// Use this for initialization
    //void Start()
    //{
    //    //playerManager = GameObject.FindGameObjectWithTag("Player").
    //}
	
    //// Update is called once per frame
    //void Update () {
	
    //}
}
