using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] GameObject	_camObj;
	RaycastHit					_hit;
	Camera						_camera;
	NavMeshAgent				_mNavMeshAgent;
	Animator					_mAnimator;
	bool						_ennemiSelected = false;
	

	// Use this for initialization
	void Start ()
	{
		_camera = _camObj.GetComponent<Camera>();
		_mNavMeshAgent = GetComponent<NavMeshAgent>();
		_mAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
		if (Input.GetMouseButton(0))
		{
			if (Physics.Raycast(ray, out _hit, 50))
			{
				// Debug.Log(_hit.collider.name);
				_mNavMeshAgent.isStopped = false;
				if (_hit.collider.gameObject.tag == "BattleGround")
				{
					_mNavMeshAgent.destination = _hit.point;
					_mAnimator.Play("Running");
					_ennemiSelected = false;
				}
				else if (_hit.collider.gameObject.tag == "Ennemi")
				{
					_ennemiSelected = true;
					Debug.Log("You Hit Ennemi");
				}
			}
		}
		Vector3 relativePos = -_hit.point + transform.position;
		if (relativePos.magnitude < 1.5f && _ennemiSelected == false)
			_mAnimator.Play("Idle");
		else if (_ennemiSelected)
			PlayerAttack(relativePos);
	}

	void PlayerAttack(Vector3 relativePos)
	{
		if (relativePos.magnitude > 10f)
		{
			_mAnimator.Play("Running");
			_mNavMeshAgent.destination = _hit.point;
		}
		else
		{
			_mNavMeshAgent.isStopped = true;
			// transform.LookAt(_hit.collider.gameObject.transform.position);
			// transform.LookAt(_hit.point);
			_mAnimator.Play("SingleShoot");
		}
	
	}
}
