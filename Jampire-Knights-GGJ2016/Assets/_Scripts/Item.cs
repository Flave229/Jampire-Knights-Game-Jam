using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    bool collected = false;
    float timeSinceCollection = 0;

	void Start()
    {
	
	}
	
	void Update()
    {
	    if (collected)
        {
            transform.position += Vector3.up * 0.5f * Time.deltaTime;
            transform.Rotate(transform.up, 90 * Time.deltaTime);
            timeSinceCollection += Time.deltaTime;
            if (timeSinceCollection >= 2.5f)
            {
                Destroy(gameObject);
            }
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (!collected)
            {
                collected = true;
            }
        }
    }
}
