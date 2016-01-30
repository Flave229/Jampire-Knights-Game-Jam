using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    public float speed;
    Transform target;
    Rigidbody rigidBody;
    Health health;

    public float attackRange;
    public int attackDamage;
    public float attackCooldown;
    float attackTimer;

	void Start()
    {
        target = null;
        rigidBody = GetComponent<Rigidbody>();
        health = GetComponent<Health>();
        attackTimer = attackCooldown;
	}
	
	void FixedUpdate()
    {
        Vector3 targetPos = target ? target.position : new Vector3(0, 0, 0);
        Vector3 deltaPos = (targetPos - transform.position);
        if (deltaPos.sqrMagnitude <= attackRange * attackRange)
        {
            if (!target) return;
            //attack
            if (attackTimer <= 0)
            {
                Health targetHealth = target.gameObject.GetComponent<Health>();
                if (targetHealth)
                {
                    targetHealth.addHealth(-attackDamage);
                }
                attackTimer = attackCooldown;
            }
            else
            {
                attackTimer -= Time.deltaTime;
            }
        }
        else
        {
            Vector3 directionToMove = deltaPos.normalized;
            directionToMove.y = 0;
            rigidBody.MovePosition(transform.position + directionToMove * speed * Time.deltaTime);
        }
	}

    void Update()
    {
        if (health.health <= 0)
        {
            ScoreCTRL.addScore(20);
            Destroy(gameObject);
        }
    }

    public void setTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
