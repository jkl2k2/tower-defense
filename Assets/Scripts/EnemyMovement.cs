using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;

    public NavMeshAgent agent;

    public GameObject destination;

    private void Start()
    {
        enemy = GetComponent<Enemy>();

        destination = GameObject.FindWithTag("Finish");
        
        agent.speed = enemy.startSpeed;
        agent.acceleration = enemy.startRotationSpeed;
    }
    
    private void Update()
    {
        agent.SetDestination(destination.transform.position);
        
        if (Vector3.Distance(transform.position, destination.transform.position) <= 1f)
        {
            EndPath();
        }
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
