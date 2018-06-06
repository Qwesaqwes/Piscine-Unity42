using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour
{
	private PlayerController	_player;
	private FanActivation		_fan;
	
	void Start()
	{
		_player = GameObject.Find("Player").GetComponent<PlayerController>();
		_fan = GameObject.Find("prop_fan_005").GetComponent<FanActivation>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (gameObject.tag == "SpotLight")
			_player._detectionSpeed = 1f;
		else if (gameObject.tag == "Camera")
		{
			if (_fan.particleActivated)
				_player._detectionSpeed = 1f;
			else if(_fan.particleActivated == false)
				_player._detectionSpeed = 10f;
		}
		_player.detected = true;
	}	

	void OnTriggerExit(Collider other)
	{
		// Debug.Log("You exited");
		// other.gameObject.GetComponent<PlayerController>().detected = false;
		_player._detectionSpeed = 0.2f;
		_player.detected = false;
	}
}
