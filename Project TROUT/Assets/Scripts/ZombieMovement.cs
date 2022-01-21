using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
	[SerializeField]
	Transform playerPosition;
	NavMeshAgent zombieAgent;
	
	void Start()
	{
		zombieAgent = this.GetComponent<NavMeshAgent>();
		playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

	}

	void Update()
	{
		Vector3 target = playerPosition.position;
		zombieAgent.SetDestination(target);
	}
}