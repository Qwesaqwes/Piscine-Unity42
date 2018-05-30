using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript_ex00 : MonoBehaviour
{
	public GameObject		player;
	public string			typePlayer;
	private static float	_speedPlayer = 1;
	private bool			_selectedPlayer = false;
	private bool			_grounded = true;

	// Use this for initialization
	void Start ()
	{
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
		if (typePlayer == "Thomas")
		{
			_selectedPlayer = true;
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		choosePlayer();
		if (_selectedPlayer)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * _speedPlayer * 3, GetComponent<Rigidbody2D>().velocity.y);
			if (Input.GetKeyDown("space") && _grounded)
			{
				GetComponent<Rigidbody2D>().AddForce(new Vector3(0,5,0), ForceMode2D.Impulse);
				_grounded = false;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Player")
		{
			_grounded = true;
		}
	}
	
	private void choosePlayer()
	{
		if (Input.GetKeyDown("1"))
		{
			_selectedPlayer = false;
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			if (typePlayer == "Thomas")
			{
				_selectedPlayer = true;
				GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
			}
		}
		else if (Input.GetKeyDown("2"))
		{
			_selectedPlayer = false;
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			if (typePlayer == "John")
			{
				_selectedPlayer = true;
				GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
			}
		}
		else if (Input.GetKeyDown("3"))
		{
			_selectedPlayer = false;
				GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			if (typePlayer == "Claire")
			{
				_selectedPlayer = true;
				GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
			}
		}
		else if (Input.GetKeyDown("r"))
		{
			_grounded = true;
			Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
		}
	}
}
