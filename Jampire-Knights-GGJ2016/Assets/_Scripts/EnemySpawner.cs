using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float radius;
    float timer;

	void Start()
    {
        timer = 0;
	}
	
	void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            timer -= 1.0f;
            Vector3 pos = Random.onUnitSphere;
            pos.y = 0;
            pos.Normalize();
            pos *= radius;//on unit circle in xz plane with radius
            pos.y += 0.5f;//height of enemy (or we could put the enemies origin at its feet idk)
            Quaternion rot = Quaternion.LookRotation(-pos);//look towards the center when spawned, not important when enemy class controls rotation
            Instantiate(enemyPrefab, pos, rot);
        }
	}
}
