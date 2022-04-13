using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private EnemyDrop dropCube;

    private Transform player_position;
    private NavMeshAgent agent;
    private EnemyAnimation animation;
    private float timer;
    private bool isRunning;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animation = GetComponent<EnemyAnimation>();
        SetAgentDestionation();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Vector3.Distance(transform.position, player_position.position) < 1.7 )
        {
            isRunning = true;
           
            if(timer > 1)
            {
                animation.AttackAnimation();
                PlayerHealth._instance.TakeDamage(damage);
                timer = 0;
            }
        }
        else if(Vector3.Distance(transform.position, player_position.position) > 1.5 )
        {
            SetAgentDestionation();
            isRunning = true;
        }
    }
    private void SetAgentDestionation()
    {
        if (isRunning)
        {
            agent.SetDestination(player_position.position);
            animation.RunAnimation();
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Instantiate(dropCube, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void GetPlayerTransform(Transform player) => player_position = player;
}
