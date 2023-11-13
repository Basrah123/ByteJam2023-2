using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent myAgent;
    Transform player;
    public bool isAlive = true;
    [SerializeField] public float maxDistance = 10f; 
    [SerializeField] float sizeModifier = 1f; // Unimplemented
    [SerializeField] float movementSpeed = 3f;
    [SerializeField] int health;
    [SerializeField] float damageModifier; // Unimplemented
    [SerializeField] bool isRanged; // Unimplemented
    [SerializeField] float shootingSpeed; // Unimplemented
    [SerializeField] float meleeDistance = 1f;
    [SerializeField] float attackTime = 1f;
    private float timeSinceLastAttack = 0f;

    private void Start()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        player = FindPlayer();
        myAgent = GetComponent<NavMeshAgent>();
        if (myAgent == null)
        {
            print("no mesh agent on " + this.gameObject.name);
        }
        Health myHealth = GetComponent<Health>();
        if (myHealth == null)
        {
            gameObject.AddComponent<Health>();

        }
        myHealth.setHealth(health);

        myAgent.speed = movementSpeed;

    }

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        Movement();
        DamageLogic();
        RotateMe();
    }

    private void RotateMe()
    {
        Vector3 directionToPlayer = player.position - transform.position;

        // Ignore the y-component of the direction, to keep the rotation only around the y-axis
        directionToPlayer.y = 0f;

        // Set the rotation to face the player only along the Y-axis
        transform.rotation = Quaternion.LookRotation(directionToPlayer.normalized, Vector3.up);
    }
    private void DamageLogic()
    {
        if (IsPlayerInLOS())
        {
            if (Vector3.Distance(transform.position,player.transform.position) < meleeDistance && timeSinceLastAttack > attackTime)
            {
                timeSinceLastAttack= 0f;
                DoDamage();
            }
        }
    }
    private void DoDamage()
    {

        player.GetComponent<Health>().DamageHealth(Mathf.RoundToInt(10 * damageModifier));
    }

    private void Movement()
    {

       

        // Handle position
        if (IsPlayerInLOS())
        {
            myAgent.isStopped = false;
            myAgent.SetDestination(player.position);
        }
        else
        {
            myAgent.isStopped = true;
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
        player = FindPlayer();
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, meleeDistance);
    }
}
