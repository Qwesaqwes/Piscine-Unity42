using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFence : MonoBehaviour
{
	private PlayerController _player;
	// Use this for initialization
	void Start ()
	{
		_player = GameObject.Find("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		_player._walkingSound.Stop();
		_player.playerLose = true;
	}	
}
