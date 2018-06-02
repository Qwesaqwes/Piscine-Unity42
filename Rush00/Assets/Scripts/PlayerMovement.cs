using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private Vector3		mousePos;
	private float		_playerSpeed = 10.0f;
	private Rigidbody2D	_playerRb2D;
	// Use this for initialization
	void Start ()
	{
		_playerRb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		playerRotationToMouse();	//Function to rotate PJ where the mouse is

	}

	void FixedUpdate() //All our physics calculations should be done in Fixed Update
	{
		// _playerRb2D.velocity = Vector2.ClampMagnitude()
		_playerRb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * _playerSpeed, Input.GetAxis("Vertical") * _playerSpeed);
		
	}

	void playerRotationToMouse()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        mousePos.x = mousePos.x - transform.position.x;
        mousePos.y = mousePos.y - transform.position.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		angle +=90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
}
