using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent Zombie;
    public Transform target;
    public float distanceThreshold = 10f;

    public enum AIstate { idle, patrol, chasing, attack };

    public AIstate aiState = AIstate.idle;

    // Start is called before the first frame update
    void Start()
    {
        Zombie = GetComponent<NavMeshAgent>();
        StartCoroutine(Think());
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        //Zombie.SetDestination(target.position);
    }

    IEnumerator Think()
    {
        while (true)
        {
            switch (aiState)
            {
                case AIstate.idle:
                    float distance = Vector3.Distance(target.position, transform.position);
                    if (distance < distanceThreshold)
                    {
                        aiState = AIstate.chasing;
                    }
                    Zombie.SetDestination(transform.position);
                    break;
                case AIstate.patrol:
                    distance = Vector3.Distance(target.position, transform.position);
                    if (distance < distanceThreshold)
                    {
                        aiState = AIstate.chasing;
                    }
                    //random directions


                    break;
                case AIstate.chasing:
                    Zombie.SetDestination(target.position);
                    distance = Vector3.Distance(target.position, transform.position);
                    if (distance > distanceThreshold)
                    {
                        aiState = AIstate.idle;
                    }
                    break;
                case AIstate.attack:
                    Zombie.SetDestination(target.position);


                    break;
                default:
                    break;
            }
        }
    }
}
