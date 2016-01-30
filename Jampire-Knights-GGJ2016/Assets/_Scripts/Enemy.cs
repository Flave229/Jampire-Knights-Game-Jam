using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public float speed;
    Vector3 targetPos;
    Rigidbody rigidBody;

	void Start()
    {
        targetPos = new Vector3(0, 0, 0);
        //targetPos = GameObject.Find("Obelisk-Thing").transform.position;
        rigidBody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate()
    {
        Vector3 directionToMove = (targetPos - transform.position).normalized;
        directionToMove.y = 0;
        rigidBody.MovePosition(transform.position + directionToMove * speed * Time.deltaTime);
	}
}
