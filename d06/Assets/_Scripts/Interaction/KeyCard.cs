using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
	private PlayerController	_player;
	[HideInInspector] public bool	showKeyInfo = false;

	// Use this for initialization
	void Start ()
	{
		_player = GameObject.Find("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.F) && showKeyInfo)
		{
			_player._playerHaveKey = true;
			showKeyInfo = false;
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		showKeyInfo = true;
	}

	void OnTriggerExit(Collider other)
	{
		showKeyInfo = false;
	}
}
