using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanActivation : MonoBehaviour
{
	private ParticleSystem		_particles;
	public bool				playerEnter = false;
	public bool				particleActivated = false;

	// Use this for initialization
	void Start ()
	{
		_particles = GameObject.Find("SmokeParticle").GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.E) && playerEnter)
		{
			_particles.Play();
			particleActivated = true;
		}
		if (Input.GetKeyDown(KeyCode.Q) && playerEnter)
		{
			_particles.Stop();
			particleActivated = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		playerEnter = true;
	}

	void OnTriggerExit(Collider other)
	{
		playerEnter = false;
	}
}
