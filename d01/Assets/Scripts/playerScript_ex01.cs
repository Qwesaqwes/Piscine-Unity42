using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerScript_ex01 : MonoBehaviour
{
	public GameObject[]	player;
	private static int		_selectedPlayer = 0;
	private static float	_speedPlayer = 0.1f;
	private static float	_powerJump = 5;
	public static bool		_grounded = true;
	// Use this for initialization
	void Start ()
	{
			player[0].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
			player[1].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			player[2].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		choosePlayer();
		if (Input.GetKey("left"))
		{
			player[_selectedPlayer].transform.position = new Vector3(player[_selectedPlayer].transform.position.x - _speedPlayer, player[_selectedPlayer].transform.position.y, 0);
			
			// player[_selectedPlayer].GetComponent<Rigidbody2D>().velocity = Vector2.left * _speedPlayer * 40;
		}
		if (Input.GetKey("right"))
		{
			player[_selectedPlayer].transform.position = new Vector3(player[_selectedPlayer].transform.position.x + _speedPlayer, player[_selectedPlayer].transform.position.y, 0);
			// player[_selectedPlayer].GetComponent<Rigidbody2D>().velocity = Vector2.right * _speedPlayer * 40;
		}
		if (Input.GetKeyDown("space") && _grounded)
		{
			// transform.position = new Vector3(player[_selectedPlayer].transform.position.x - _speedPlayer, player[_selectedPlayer].transform.position.y, 0);
			// transform.position = Vector3.MoveTowards(transform.position, player[_selectedPlayer].transform.position, 10);
			
			// transform.localScale = new Vector3(0.1f,0.1f, 0);
			player[_selectedPlayer].GetComponent<Rigidbody2D>().AddForce(new Vector2(0,_powerJump), ForceMode2D.Impulse);
			// GetComponent<Rigidbody2D>().AddForce(new Vector2(0,_powerJump), ForceMode2D.Impulse);
			_grounded = false;
		}
	}

	private void OntriggerEnter2D(Collider2D other)
	{
		Debug.Log("ASDFASDF");
		// if (other.gameObject.tag == "Player")
		// {
		// 	Physics2D.IgnoreCollision(player[0].GetComponent<Collider2D>(), GetComponent<Collider2D>());
		// 	Physics2D.IgnoreCollision(player[1].GetComponent<Collider2D>(), GetComponent<Collider2D>());
		// 	Physics2D.IgnoreCollision(player[2].GetComponent<Collider2D>(), GetComponent<Collider2D>());
		// }
		if (other.tag == "Ground")
		{
			_grounded = true;
		}
	}

	private void choosePlayer()
	{
		if (Input.GetKeyDown("1"))
		{
			_selectedPlayer = 0;
			_speedPlayer = 0.1f;
			_powerJump = 7;
			player[0].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
			player[1].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			player[2].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

		}
		else if (Input.GetKeyDown("2"))
		{
			_selectedPlayer = 1;
			_speedPlayer = 0.2f;
			_powerJump = 7.5f;
			player[0].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			player[1].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
			player[2].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
		}
		else if (Input.GetKeyDown("3"))
		{
			_selectedPlayer = 2;
			_speedPlayer = 0.05f;
			_powerJump = 4.5f;
			player[0].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			player[1].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			player[2].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
		}
		else if (Input.GetKeyDown("r"))
		{
			_selectedPlayer = 0;
			_grounded = true;
			Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

		}
	}
}
