using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterFollow : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyAgent.SetDestination(player.position);
    }
}
