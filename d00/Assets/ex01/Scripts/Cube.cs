using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
	private static float movementSpeed;
	public char typeCube;

	// Use this for initialization
	void Start ()
	{
		movementSpeed = Random.Range(0.1f, 0.5f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3(transform.position.x, (transform.position.y - movementSpeed), 0);
		if (transform.position.y < -10f)
			GameObject.Destroy(gameObject);
		if (typeCube == 'a' && Input.GetKey("a") && transform.position.y < 0 && transform.position.y > -5)
		{
			GameObject.Destroy(gameObject);
			Debug.Log(transform.position.y + 4);
		}
		if (typeCube == 'd' && Input.GetKey("d") && transform.position.y < 0 && transform.position.y > -5)
		{
			GameObject.Destroy(gameObject);	
			Debug.Log(transform.position.y + 4);
		}
		if (typeCube == 's' && Input.GetKey("s") && transform.position.y < 0 && transform.position.y > -5)
		{
			GameObject.Destroy(gameObject);	
			Debug.Log(transform.position.y + 4);
		}
	}
}