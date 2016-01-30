using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

    public Transform itemPrefab;
    public Transform itemOrigin;
    public float radius;
    float timer;

	// Use this for initialization
    void Start()
    {
        timer = 0;
	}
	
	// Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5.0f)
        {
            timer -= 5.0f;
            Vector3 pos = Random.onUnitSphere;
            pos.y = 0;
            //pos.Normalize();
            pos *= radius;//on unit circle in xz plane with radius
            Quaternion rot = Quaternion.LookRotation(-pos);//look towards the center when spawned, not important when enemy class controls rotation
            Transform enemy = (Transform)Instantiate(itemPrefab);
            enemy.parent = itemOrigin;
            enemy.localPosition = pos;
            enemy.rotation = rot;
        }
	}
}
