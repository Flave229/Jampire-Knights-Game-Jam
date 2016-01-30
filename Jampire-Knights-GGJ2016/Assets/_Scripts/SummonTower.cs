using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SummonTower : MonoBehaviour {

    SelectTower selectTower;
    public List<Transform> towerPrefab = new List<Transform>();
    public float defaultCooldown;
    float currCooldown;

    public Transform towerSpawnPoint;


	// Use this for initialization
	void Start () 
    {
        currCooldown = defaultCooldown;
	    // Needs to see currently selected tower from UI
        selectTower = GameObject.Find("SelectedTower").GetComponent<SelectTower>();
	}
	
	// Update is called once per frame
	void Update () {
        // if summon is cooling down, take away time from the cooler
        if (currCooldown > 0)
        {
            currCooldown -= Time.deltaTime;

            if (currCooldown < 0)
            {
                currCooldown = 0;
            }
        }

        if (currCooldown == 0)
        {
            // Nothing needs to be done unless right mouse button clicked
            bool clicked = Input.GetMouseButtonDown(1);// 0 = left click, 1 = right click, 2 = middle click

            if (clicked)
            {
                //Reset timer
                currCooldown = defaultCooldown;

                // Get the string of the currently selected tower
                string tower = selectTower.getSelectedTower();
                Transform correctTower;

                for (int i = 0; i < towerPrefab.Count; i++)
                {
                    if (towerPrefab[i].name.Equals(tower))
                    {
                        // Check if player can afford
                        int currScore = ScoreCTRL.getScore();
                        int cost = towerPrefab[i].GetComponent<Tower>().getCost();
                        if (currScore >= cost)
                        {
                            // Take away from score
                            ScoreCTRL.addScore(-1 * cost);

                            int floorMask = LayerMask.GetMask("Floor");

                            // Create a ray from the mouse cursor on screen in the direction of the camera.
                            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                            // Create a RaycastHit variable to store information about what was hit by the ray.
                            RaycastHit floorHit;

                            // Perform the raycast and if it hits something on the floor layer...
                            if (Physics.Raycast(camRay, out floorHit, 100f, floorMask))
                            {
                                correctTower = (Transform)Instantiate(towerPrefab[i]);

                                correctTower.transform.position = floorHit.point;
                                correctTower.transform.position = new Vector3(floorHit.point.x, correctTower.transform.localScale.y / 2, floorHit.point.z);
                                correctTower.transform.rotation = gameObject.transform.rotation;
                            }

                            //correctTower.transform.position = gameObject.transform.position;

                            //correctTower = Instantiate(towerPrefab[i], towerSpawnPoint.position, towerSpawnPoint.rotation) as Transform;
                        }
                    }
                }
            }
        }
	}
}
