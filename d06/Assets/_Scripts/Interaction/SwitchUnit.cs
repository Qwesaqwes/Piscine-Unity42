using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchUnit : MonoBehaviour
{
	[HideInInspector] public bool	showSwitchInfo = false;
	private PlayerController	_player;
	[SerializeField] private GameObject		_door;
	private AudioSource	openswitch;
	private AudioSource doorOpen;

	// Use this for initialization
	void Start ()
	{
		_player = GameObject.Find("Player").GetComponent<PlayerController>();
		openswitch = GetComponent<AudioSource>();
		doorOpen = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.T) && showSwitchInfo && _player._playerHaveKey)
		{
			//OPEN DOOR
			Debug.Log("Opening door");
			openswitch.enabled = true;
			openswitch.Play();
			doorOpen.enabled = true;
			doorOpen.Play();
			_door.GetComponent<Animator>().enabled = true;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		showSwitchInfo = true;
	}

	void OnTriggerExit(Collider other)
	{
		showSwitchInfo = false;
	}

	
}
