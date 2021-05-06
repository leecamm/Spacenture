using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    public Transform target;
    public float chaseRange;
    public float attackRange;

    public int damage;
    private float lastAttackTime;
    public float attackDelay;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        // check the distance between enemies and player to see if the player is close enough to attack
        /*float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            //Check to see if enough time has passed since we last attacked
            if (Time.time > lastAttackTime + attackDelay)
            {
                target.SendMessage("TakeDamage", damage);
                //Record the time we attacked
                lastAttackTime = Time.time;
            }
        }
        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }*/
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            target.SendMessage("TakeDamage", damage);
            
        }
    }
}
