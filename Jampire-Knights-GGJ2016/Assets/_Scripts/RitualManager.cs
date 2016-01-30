using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RitualManager : MonoBehaviour
{
    enum State
    {
        NOTHING,
        PERFORMING_RITUAL,
        BUFFING
    }
    enum Buff
    {
        HEALTH_REGEN,
        REPAIR_TOWERS
    }
    State state;
    Buff buff;
    float timer;

	void Start()
    {
        state = State.NOTHING;
        timer = 0;
	}
	
	void Update()
    {
	    switch (state)
        {
            case State.PERFORMING_RITUAL:
                {
                    transform.Rotate(Vector3.up, 45 * Time.deltaTime);
                    if (transform.rotation.eulerAngles.y >= 90)
                    {
                        transform.rotation.SetAxisAngle(Vector3.up, 0);
                        state = State.BUFFING;
                    }
                    break;
                }
            case State.BUFFING:
                {
                    PerformBuff();
                    break;
                }
        }
	}

    void PerformBuff()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            state = State.NOTHING;
            return;
        }
        switch (buff)
        {
            case Buff.REPAIR_TOWERS:
                {
                    foreach (GameObject tower in GameObject.FindGameObjectsWithTag("Tower"))
                    {
                        Health h = tower.GetComponent<Health>();
                        if (h)
                        {
                            h.addHealth(100 * Time.deltaTime);
                        }
                    }
                    GameObject.FindGameObjectWithTag("Obelisk").GetComponent<Health>().addHealth(100 * Time.deltaTime);
                    break;
                }
            case Buff.HEALTH_REGEN:
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().addHealth(20 * Time.deltaTime);
                    break;
                }
        }
    }

    public void PerformRitual(List<GameObject> items)
    {
        buff = new Buff[] { Buff.HEALTH_REGEN, Buff.HEALTH_REGEN, Buff.HEALTH_REGEN, Buff.REPAIR_TOWERS }[Random.Range(0, 4)];
        state = State.PERFORMING_RITUAL;
        timer = 5;
    }
}
