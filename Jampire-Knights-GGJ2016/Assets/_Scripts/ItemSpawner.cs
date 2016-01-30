using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour {

    public Transform[] itemPrefabs;
    public Transform itemOrigin;
    public float minRadius;
    public float maxRadius;
    float timer;
    enum State
    {
        _WAITING,
        WAITING_TO_SPAWN,
        SPAWN_ITEMS,
        COLLECTING_ITEMS,
        PERFORMING_RITUAL
    };
    State currentState, nextState;
    List<GameObject> items = new List<GameObject>();

    void Start()
    {
        timer = 0;
        currentState = State.WAITING_TO_SPAWN;
	}

    void ChangeStateAfter(State nextState, float seconds)
    {
        currentState = State._WAITING;
        this.nextState = nextState;
        timer = seconds;
    }
	
    void Update()
    {
        switch (currentState)
        {
            case State._WAITING:
                {
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        currentState = nextState;
                    }
                    break;
                }
            case State.WAITING_TO_SPAWN:
                {
                    ChangeStateAfter(State.SPAWN_ITEMS, Random.Range(5, 20));
                    break;
                }
            case State.SPAWN_ITEMS:
                {
                    int numItemsToSpawn = Random.Range(1, 3);
                    for (int i = 0; i < numItemsToSpawn; i++)
                    {
                        SpawnItem();
                    }
                    ChangeStateAfter(State.COLLECTING_ITEMS, 0);
                    break;
                }
            case State.COLLECTING_ITEMS:
                {
                    foreach (GameObject item in items)
                    {
                        if (item == null)
                        {
                            items.Remove(item);
                            break;
                        }
                    }
                    if (items.Count == 0)
                    {
                        ChangeStateAfter(State.PERFORMING_RITUAL, 0);
                    }
                    break;
                }
            case State.PERFORMING_RITUAL:
                {
                    GameObject.FindGameObjectWithTag("Obelisk").GetComponent<RitualManager>().PerformRitual(null);
                    ChangeStateAfter(State.WAITING_TO_SPAWN, 0);
                    break;
                }
        }
	}

    void SpawnItem()
    {
        Vector3 pos = Random.onUnitSphere;
        pos.y = 0;
        pos.Normalize();
        pos *= Random.Range(minRadius, maxRadius);//on unit circle in xz plane with radius
        Quaternion rot = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up);
        Transform item = (Transform)Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
        item.parent = itemOrigin;
        item.localPosition = pos;
        item.rotation = rot;
        items.Add(item.gameObject);
    }
}
