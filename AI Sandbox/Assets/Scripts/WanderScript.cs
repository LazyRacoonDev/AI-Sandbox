using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Wander : MonoBehaviour {

    //pilla el radio de busqueda de objetivo
    public float wanderRadius;
    //pilla el tiempo de busqueda de objetivo
    public float wanderTimer;
    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    void Start (){
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

      void Update () {
        timer += Time.deltaTime;
 
        if (timer >= wanderTimer) {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }
}