using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiController : MonoBehaviour
{
	[SerializeField]
	private Transform[]		_waypoints;
	[SerializeField]
	// private Transform		_getAwayPoint;
	private float			_moveSpeed = 5f;
	private int				_waypointIndex = 0;
	private bool			_playerDetected = false;
	private Rigidbody2D		_rb2D;
	private Transform		_playerPos;
	float					timer = 0.0f;
	public	GameObject		ennemiBullet;

	// Use this for initialization
	void Start ()
	{
		Debug.Log(transform.position.x);
		// if (_waypoints != null)
		// {
		// 	transform.position = _waypoints[_waypointIndex].transform.position;
		// }

		// _rb2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update ()
	{
		if (_playerDetected && _playerPos)
		{
			Vector3 mousePos = _playerPos.position;
			mousePos.z = transform.position.z;
			mousePos.x = mousePos.x - transform.position.x;
			mousePos.y = mousePos.y - transform.position.y;
			float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
			angle +=90;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
			transform.position = Vector2.MoveTowards(transform.position, _playerPos.position, _moveSpeed * Time.deltaTime);
			
			timer += Time.deltaTime;
			Vector3 mag = _playerPos.position - transform.position;
			LayerMask layer = LayerMask.GetMask("Character", "Sceneries");
			RaycastHit2D hit = Physics2D.Raycast(transform.position, mag, 5f, layer);
			Debug.DrawRay(transform.position, mag, Color.blue);
			if (hit.collider != null)
			{
				Debug.Log(hit.collider.gameObject.tag);
				if (hit.collider.gameObject.tag == "Character")
				{
					// Debug.Log("asdfadf");
					if ((timer > 0.5 && timer < 0.55) || (timer > 1.5 && timer < 1.55) || (timer > 2.5 && timer < 2.55) || (timer > 3.5 && timer < 3.55)
					|| (timer > 4.5 && timer < 4.55) || (timer > 5.5 && timer < 5.55) || (timer > 6.5 && timer < 6.55))
					{
						Instantiate(ennemiBullet, transform.position, Quaternion.identity);
					}
				}
				// else if (hit.collider.gameObject.tag == "wall")
				// {
				// 	Debug.Log("ADSFADF");
				// 	Vector3 direction = Vector3.zero;
				// 	direction = _getAwayPoint.position - transform.position;
				// 	direction = direction.normalized;
				// 	GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * _moveSpeed * 2, direction.y * _moveSpeed * 2);
				// }
			}
			// Debug.Log(timer);
			
			if (timer > 7)
			{
				_playerDetected = false;
				timer = 0;
			}
		}

		if (_waypointIndex < _waypoints.Length && _waypoints != null && _playerDetected == false)
		{
			transform.Rotate(0, 0, 1f);
			Vector3 direction = Vector3.zero;
			direction = _waypoints[_waypointIndex].transform.position - transform.position;
			if (direction.magnitude < 0.5f)
			{
				if (_waypointIndex < _waypoints.Length - 1)
					_waypointIndex++;
				else
					_waypointIndex = 0;
			}
			direction = direction.normalized;
			GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * _moveSpeed, direction.y * _moveSpeed);
		}
		else
			_waypointIndex = 0;
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Character")
		{
			// Debug.Log("Player entered");
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
		// else
		// 	_playerDetected = false;

	}
}
