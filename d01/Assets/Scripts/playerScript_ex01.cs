using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerScript_ex01 : MonoBehaviour
{
	public GameObject		player;
	public string			typePlayer;
	private static float	_speedPlayer;
	private bool			_selectedPlayer = false;
	private bool			_grounded = true;
	private float				_jumpPower;
	private static Scene	_scene;
	

	// Use this for initialization
	void Start ()
	{
		_scene = SceneManager.GetActiveScene();
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
		if (typePlayer == "Thomas")
			initPlayer(true, 1.0f, 5);
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
				GetComponent<Rigidbody2D>().AddForce(new Vector3(0,_jumpPower,0), ForceMode2D.Impulse);
				_grounded = false;
			}
		}
		if (transform.position.y < -6)
            SceneManager.LoadScene(_scene.name);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		// Debug.Log("ASDFASD");
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Player")
			_grounded = true;
	}
	
	private void choosePlayer()
	{
		if (Input.GetKeyDown("1"))
		{
			_selectedPlayer = false;
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			if (typePlayer == "Thomas")
				initPlayer(true, 1.0f, 5);
		}
		else if (Input.GetKeyDown("2"))
		{
			_selectedPlayer = false;
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			if (typePlayer == "John")
				initPlayer(true, 1.1f, 7);
		}
		else if (Input.GetKeyDown("3"))
		{
			_selectedPlayer = false;
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			if (typePlayer == "Claire")
				initPlayer(true, 0.9f, 4.5f);
		}
		else if (Input.GetKeyDown("r"))
            SceneManager.LoadScene(_scene.name);
	}

	private void	initPlayer(bool selectedPlayer, float speedPlayer, float jumpPower)
	{
		_selectedPlayer = selectedPlayer;
		_speedPlayer = speedPlayer;
		_jumpPower = jumpPower;
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
	}
}

