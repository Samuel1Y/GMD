using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    public GameObject enemy;
    public NavMeshAgent enemyAgent;
    public GameObject enemyModel;
    public float range, chaseRange; //radius of sphere, radius of chase
    public Transform centerPoint; // middle point of the sphere
    public Transform playerPosition, enemyPosition;
    public bool isChasing;
    public AudioSource chaseJumpscare;


    void Start()
    {
        enemy = this.gameObject;
        enemyAgent = enemy.GetComponent<NavMeshAgent>();
        enemyPosition = enemy.GetComponent<Transform>();
        playerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>();
        isChasing = false;
        InvokeRepeating("CheckPlayerInRange", 2.0f, 2f); //regularly check if player is in range
    }


    void Update()
    {

        if (isChasing)
        {
            enemyAgent.SetDestination(playerPosition.position);
            //StartChasing();
            //StartCoroutine(StopChasing()); //stop the chase after some time
        }
        else //walk to random points on map
        {
            enemyModel.SetActive(false);

            enemyAgent.speed = 30f; //fast speed to walk around map
            if (enemyAgent.remainingDistance <= enemyAgent.stoppingDistance) //check if it's done with path
            {
                Vector3 point;
                if (RandomPoint(centerPoint.position, range, out point))
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 10.0f);

                    enemyAgent.SetDestination(point);
                }
            }
        }
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
    void StartChasing()
    {
        isChasing = true;
        enemyModel.SetActive(true);
        enemyAgent.speed = 8f; //slower speed so player has chance to escape
        StartCoroutine(StopChasing());
    }
    IEnumerator StopChasing()
    {
        yield return new WaitForSeconds(10f);
        Debug.Log("STOPPED CHASING");
        isChasing = false;
    }
    void CheckPlayerInRange()
    {
        if(!isChasing)
        {
            Debug.Log(Vector3.Distance(playerPosition.position, enemyPosition.position));
            if (Vector3.Distance(playerPosition.position, enemyPosition.position) < chaseRange && // compare the distance between player and enemy with chase range
                Vector3.Distance(playerPosition.position, enemyPosition.position) > 20f)            // make sure it won't start chasing when it's too close
            {
                chaseJumpscare.Play();
                StartChasing();
            }
        }

    }
}