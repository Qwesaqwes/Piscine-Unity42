using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportIN : MonoBehaviour
{
	public Transform[]	teleporLoc;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.layer == 11)
			other.transform.position = teleporLoc[0].transform.position;
		if (other.gameObject.layer == 12)
			other.transform.position = teleporLoc[1].transform.position;
		if (other.gameObject.layer == 13)
			other.transform.position = teleporLoc[2].transform.position;
	}
}
