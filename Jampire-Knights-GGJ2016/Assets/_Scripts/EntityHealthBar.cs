using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class EntityHealthBar : MonoBehaviour
{
    public Health healthComponent;
    MeshRenderer meshRenderer;
    Vector3 startScale;

	void Awake()
    {
        startScale = transform.localScale;
        meshRenderer = GetComponent<MeshRenderer>();
        //healthComponent = transform.parent.parent.GetComponentInChildren<Health>();//ohgodwhy
	}
	
	void Update()
    {
        float healthPercent = healthComponent.health / healthComponent.maxHealth;
        transform.localScale = new Vector3(startScale.x * healthPercent, startScale.y, startScale.z);
        //color
        Color color;
        if (healthPercent <= 0.25)
        {
            color = Color.red;
        }
        else if (healthPercent <= 0.5)
        {
            color = Color.yellow;
        }
        else
        {
            color = Color.green;
        }
        meshRenderer.material.color = color;
        //face camera
        Camera cam = Camera.main;
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
	}
}
