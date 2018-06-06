using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPick : MonoBehaviour
{
	[HideInInspector] public bool	playerWin = false;
	[SerializeField] GameObject player;
	private AudioSource _sound;
	private bool 		ontime = false;

	void Start()
	{
		_sound = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (playerWin && ontime == false)
		{
			_sound.Play();
			ontime = true;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		player.GetComponent<PlayerController>()._walkingSound.Stop();
		playerWin = true;
	}

	void OnTriggerExit(Collider other)
	{
		playerWin = false;
	}
}
