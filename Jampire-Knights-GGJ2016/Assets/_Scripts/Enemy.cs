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
    Animator anim;

    public float attackRange;
    public int attackDamage;
    public float attackCooldown;
    float attackTimer;
    bool alive;

	void Start()
    {
        anim = GetComponent<Animator>();
        target = null;
        rigidBody = GetComponent<Rigidbody>();
        health = GetComponent<Health>();
        attackTimer = attackCooldown;
        alive = true;
	}
	
	void FixedUpdate()
    {
        if (!alive) return;
        Vector3 targetPos = target ? target.position : new Vector3(0, 0, 0);
        Vector3 deltaPos = (targetPos - transform.position);
        if (deltaPos.sqrMagnitude <= attackRange * attackRange)
        {
            if (!target) return;
            anim.SetBool("IsRunning", false);
            //attack
            if (attackTimer <= 0)
            {
                anim.SetTrigger("Fire");
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
            anim.SetBool("IsRunning", true);
        }
	}

    void Update()
    {
        if (alive && health.health <= 0)
        {
            ScoreCTRL.addScore(20);
            Destroy(gameObject, 1.0f);
            anim.SetTrigger("Dead");
            alive = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (alive)
            {
                col.gameObject.GetComponent<Health>().addHealth(-2);
            }
        }
    }

    public void setTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
