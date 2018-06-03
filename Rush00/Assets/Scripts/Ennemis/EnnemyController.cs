using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyController : MonoBehaviour
{
	[SerializeField]
	private Transform[]		_waypoints;
	[SerializeField]
	private float			_moveSpeed = 2f;
	private int				_waypointIndex = 0;
	private bool			_playerDetected = false;
	private Rigidbody2D		_rb2D;
	private Transform		_playerPos;
	
	// Use this for initialization
	void Start ()
	{
		if (_waypoints != null)
		{
			transform.position = _waypoints[_waypointIndex].transform.position;
		}

		// _rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (_playerDetected)
		{
			Vector3 mousePos = _playerPos.position;
			mousePos.z = transform.position.z;
			mousePos.x = mousePos.x - transform.position.x;
			mousePos.y = mousePos.y - transform.position.y;
			float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
			angle +=90;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

			// _rb2D.MovePosition = Vector2.MoveTowards(transform.position, _playerPos.position, _moveSpeed * Time.fixedDeltaTime);
			transform.position = Vector2.MoveTowards(transform.position, _playerPos.position, _moveSpeed * Time.deltaTime);

			RaycastHit2D hit = Physics2D.Raycast(transform.position, _playerPos.position);
			if (hit.collider != null)
			{
				// if (hit.collider.tag != "Character" || hit.collider.tag != "Ennemi")
				// {
				// 	Debug.Log(hit.collider.tag);
				// 	_playerDetected = false;
				// }
				// else
				// 	Debug.Log("looking player");
					
			}

		
			if (transform.position == _playerPos.position)
			{
				_playerDetected = false;
			}
		}

		if (_waypointIndex < _waypoints.Length && _waypoints != null && _playerDetected == false)
		{
			// _rb2D.MovePosition = Vector2.MoveTowards(transform.position, _waypoints[_waypointIndex].transform.position, _moveSpeed * Time.fixedDeltaTime);
			transform.position = Vector2.MoveTowards(transform.position, _waypoints[_waypointIndex].transform.position, _moveSpeed * Time.deltaTime);
			if (transform.position == _waypoints[_waypointIndex].transform.position)
				_waypointIndex += 1;
		}
		else
			_waypointIndex = 0;
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Character")
		{
			Debug.Log("Player entered");
			_playerDetected = true;
			_playerPos = other.transform;
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Bullet")
		{
			Destroy(gameObject);
		}
		else
			_playerDetected = false;
		
	}
}
