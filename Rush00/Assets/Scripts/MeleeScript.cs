using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
	void Start ()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = transform.position.z;
		mousePos.x = mousePos.x - transform.position.x;
		mousePos.y = mousePos.y - transform.position.y;
		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		angle -= 90;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		transform.Translate(0, 1, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	// 	GetComponent<Rigidbody2D>().AddForce(transform.right * 100);//, ForceMode2D.Impulse);
		
		// Destroy(gameObject, 1); //only for test
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log(other.gameObject.name);
		Destroy(gameObject);	
	}
}
