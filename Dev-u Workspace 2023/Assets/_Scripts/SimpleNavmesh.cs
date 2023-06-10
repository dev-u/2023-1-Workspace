using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DevU
{
    public class SimpleNavmesh : MonoBehaviour
    {
        private NavMeshAgent _agent;
        [SerializeField] private Transform _targetPosition;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }
        private void FixedUpdate()
        {
            _agent.SetDestination(_targetPosition.position);
        }

    }
}
