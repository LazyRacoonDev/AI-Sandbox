using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollScript : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject target;

    void Seek()
    {
        agent.destination = target.transform.position;
    }
}
