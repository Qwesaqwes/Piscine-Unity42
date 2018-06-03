using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiBullet : MonoBehaviour
{
	private PlayerMovement player;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find("Character").GetComponent<PlayerMovement>();
		Vector3 mousePos = player.transform.position;
        mousePos.z = transform.position.z;
        mousePos.x = mousePos.x - transform.position.x;
        mousePos.y = mousePos.y - transform.position.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		GetComponent<Rigidbody2D>().AddForce(transform.right * 100);//, ForceMode2D.Impulse);
		// Destroy(gameObject, 1); //only for test
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log(other.gameObject.name);
		Destroy(gameObject);	
	}
}
