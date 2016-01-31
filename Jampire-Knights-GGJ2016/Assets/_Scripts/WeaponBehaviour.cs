using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponBehaviour : MonoBehaviour {

    public List<GameObject> wands = new List<GameObject>();
    public List<GameObject> projectile = new List<GameObject>();
    int selectedWeapon;
    public Transform projectileSpawnPoint;
    public Transform wandOrigin;

	// Use this for initialization
	void Start () {
        selectedWeapon = 1;

        for (int i = 0; i < wands.Count; i++)
        {
            wands[i].transform.parent = wandOrigin;
            wands[i].GetComponentInChildren<MeshRenderer>().enabled = (i == 0);
        }
	}
	
	void FixedUpdate ()
    {
        bool fire = Input.GetMouseButtonDown(0); // Left Click

        if (fire)
        {
            FireProjectile();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedWeapon = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedWeapon = 4;
        }

        UpdateStaffType();
    }

    void FireProjectile()
    {
        Instantiate(projectile[selectedWeapon - 1], projectileSpawnPoint.position, projectileSpawnPoint.rotation);
    }

    void UpdateStaffType()
    {
        for (int i = 0; i < wands.Count; i++)
        {
            wands[i].GetComponentInChildren<MeshRenderer>().enabled = (i == selectedWeapon - 1);
            //wands[i].SetActive(i == selectedWeapon - 1);
        }
    }
}
