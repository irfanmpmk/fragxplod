using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float detectionRange = 5f;
    public Transform[] patrolPoints;

    private int currentPatrolIndex;
    private Transform player;
    private bool playerDetected = false;

    void Start()
    {
        currentPatrolIndex = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartPatrol();
    }

    void Update()
    {
        if (playerDetected)
        {
            DetectPlayer();
        }
        else
        {
            Patrol();
            CheckPlayerDetection();
        }
    }

    void StartPatrol()
    {
        // Move towards the first patrol point
        transform.position = patrolPoints[currentPatrolIndex].position;
    }

    void Patrol()
    {
        if (Vector3.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
        else
        {
            Vector3 direction = (patrolPoints[currentPatrolIndex].position - transform.position).normalized;
            transform.position += direction * patrolSpeed * Time.deltaTime;
        }
    }

    void CheckPlayerDetection()
    {
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            playerDetected = true;
        }
    }

    void DetectPlayer()
    {
        // Implement logic for the enemy to move towards the player or attack
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * patrolSpeed * Time.deltaTime; // Move towards the player
    }
}