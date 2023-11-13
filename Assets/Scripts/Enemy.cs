using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent myAgent;
    Transform destination;
    public float maxDistance = 10f;
    Transform player;

    private void Start()
    {
        player = FindPlayer();
        myAgent= GetComponent<NavMeshAgent>();
        if(myAgent == null)
        {
            print("no mesh agent on " + this.gameObject.name);
        }
    }
    private void Update()
    {
        
        if (IsPlayerInLOS())
        {
            myAgent.isStopped = false;
            myAgent.SetDestination(player.position);
        }
        else
        {
            myAgent.isStopped= true;
        }
    }
    // Needs logic to raycast between AI and player
    private bool IsPlayerInLOS()
    {
       
        Vector3 directionToPlayer = player.position - transform.position;


        if (Physics.Raycast(transform.position, directionToPlayer.normalized, out RaycastHit hit, maxDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                // Player is in line of sight
                Debug.Log("Player in line of sight!");
                return true;
            }
        }
        else
        {
            // No hit, meaning the ray did not hit anything
            Debug.Log("Ray did not hit anything.");
        }

        // Player is not in line of sight
        return false;
    }

    private void Move_me(Transform destination)
    {
        myAgent.destination = destination.position;
    }

    private Transform FindPlayer()
    {
        Health[] allHeathComponents = FindObjectsOfType<Health>();
        foreach (Health health in allHeathComponents)
        {
            if(health.getIsPlayer())
            {
                return health.gameObject.transform;
            }
        }
        print("ERROR: No player in scene!!!");
        return null;
    }

    private void OnDrawGizmos()
    {
        // Draw the ray in the Scene view using Gizmos
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxDistance);
    }
}
