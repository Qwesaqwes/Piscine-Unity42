﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
	public GameObject		player;
	public string			typePlayer;
	private static bool		_thomasExit = false;
	private static bool		_johnExit = false;
	private static bool		_claireExit = false;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_johnExit && _claireExit && _thomasExit)
		{
			Debug.Log("FINISH! BRAVO!");
			_thomasExit = false;
			_johnExit = false;
			_claireExit = false;
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.layer == 11 && typePlayer == "Thomas")
			_thomasExit = true;
		if (other.gameObject.layer == 12 && typePlayer == "John")
			_johnExit = true;
		if (other.gameObject.layer == 13 && typePlayer == "Claire")
			_claireExit = true;
	}
}
