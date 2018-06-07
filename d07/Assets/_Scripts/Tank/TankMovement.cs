using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
	public int	_tankSpeed = 5;
	public float	_tankSpeedRotation = 20f;
	Rigidbody		_rb;
	float				_stamina = 15f;

	// Use this for initialization
	void Start ()
	{
		_rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		_tankSpeed = 5;
		Sprint();
		transform.Rotate(0, Input.GetAxis("Horizontal") * _tankSpeedRotation * Time.deltaTime, 0);
	}

	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.W))
			_rb.MovePosition(transform.position + transform.forward * _tankSpeed * Time.fixedDeltaTime);
		if (Input.GetKey(KeyCode.S))
			_rb.MovePosition(transform.position - transform.forward * _tankSpeed * Time.fixedDeltaTime);
	}

	void Sprint()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			if (_stamina > 0)
			{
				_tankSpeed = 10;
				_stamina -= Time.deltaTime * 10f;
				// Debug.Log(_stamina);
			}
		}
		if (_stamina < 30f)
		{
			_stamina += Time.deltaTime * 5f;
			// Debug.Log(_stamina);
		}
	}
}
