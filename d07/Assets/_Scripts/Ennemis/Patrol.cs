using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
	public Transform PlayerTarget;
	public Transform EnnemiTarget;
	[HideInInspector] public NavMeshAgent	_agent;

	// Use this for initialization
	void Start ()
	{
		_agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		_agent.SetDestination(PlayerTarget.position);
	}

	void FixedUpdate()
	{
		// LayerMask layer = LayerMask.GetMask("Tank", "Battleground", "Ennemis");
		// RaycastHit hitPlayer;
		// RaycastHit hitEnnemi;
		// if (PlayerTarget == null)
		// 	_agent.SetDestination(EnnemiTarget.position);
		// else if (EnnemiTarget == null)
		// 	_agent.SetDestination(PlayerTarget.position);
		// else
		// {
		// 	Physics.Raycast(transform.position, (PlayerTarget.position - transform.position), out hitPlayer, 50f, layer);
		// 	Debug.DrawRay(transform.position, (PlayerTarget.position - transform.position) * 250, Color.green);
		// 	Physics.Raycast(transform.position, (EnnemiTarget.position - transform.position), out hitEnnemi, 50f, layer);
		// 	Debug.DrawRay(transform.position, (EnnemiTarget.position - transform.position) * 250, Color.black);
		// 	Debug.Log(hitPlayer.distance);
		// 	Debug.Log(hitEnnemi.distance);
			
		// 	if (hitPlayer.distance < hitEnnemi.distance)
		// 		_agent.SetDestination(PlayerTarget.position);
		// 	else
		// 		_agent.SetDestination(EnnemiTarget.position);
		// }
	}
}
