using UnityEngine;
using UnityEngine.AI;

/*
public class VeryBasicWanderAI : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent = null;
    [SerializeField]
    private LayerMask floorMask = 0;

    private float thresholdDistance = 1.0f; // Distancia mínima para considerar que ha llegado al destino

    // Update is called once per frame
    void Update()
    {
        DoWander();
    }

    private void DoWander()
    {
        // Verifica si el agente no está calculando una nueva ruta y si está cerca del destino
        if (!agent.pathPending && agent.remainingDistance <= thresholdDistance)
        {
            // Pilla una posición aleatoria en un radio de 10 metros
            agent.SetDestination(RandomNavSphere(transform.position, 10.0f, floorMask));
        }
    }

    Vector3 RandomNavSphere(Vector3 origin, float distance, LayerMask layerMask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layerMask);

        return navHit.position;
    }
}
*/
/*
public class Wander : MonoBehaviour

{
    public float wanderRadius;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false();
        Wandering();
    }

    void Wandering()
    {
        if
        agent.destination = RandomNavSphere(transform.position, wanderRadius, -1);
    }

    void Update()
    {
        if ()
    }
}
*/
public class Wander : MonoBehaviour {
 
    public float wanderRadius;
    public float wanderTimer;
 
    private Transform target;
    private NavMeshAgent agent;
    private float timer;
 
    // Use this for initialization
    void OnEnable () {
        agent = GetComponent<NavMeshAgent> ();
        timer = wanderTimer;
    }
 
    // Update is called once per frame
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