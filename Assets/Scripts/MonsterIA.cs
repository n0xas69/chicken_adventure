using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterIA : MonoBehaviour
{

    NavMeshAgent agent;
    public GameObject[] point;
    GameObject player;
    float triggerDistance = 6; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(point[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = agent.remainingDistance;
        if (distance <= 0.05f)
        {
            int dest = Random.Range(0, 4);
            agent.SetDestination(point[dest].transform.position);
        }

        SearchPlayer();
    }

    public void SearchPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // si le joueur approche dans la zone d'aggro du monstre
        if (distanceToPlayer <= triggerDistance)
        {
            agent.SetDestination(player.transform.position);
            agent.speed = 4;
            agent.angularSpeed = 300;
            agent.acceleration = 4;

        }
        else
        {
            agent.speed = 2;
            agent.angularSpeed = 200;
            agent.acceleration = 2;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, triggerDistance);
    }
}
