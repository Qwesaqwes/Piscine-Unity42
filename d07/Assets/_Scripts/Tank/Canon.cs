using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
	[SerializeField] private ParticleSystem	_gunshootParticles;
	[SerializeField] private ParticleSystem _misileshootParticles;
	[SerializeField] private ParticleSystem _impactshootParticles;
	[SerializeField] private AudioClip[]	_sounds;

	[HideInInspector] public int		ammo = 10;
	AudioSource	_shoots;

	// Use this for initialization
	void Start ()
	{
		_shoots = gameObject.AddComponent<AudioSource>();
		_shoots.playOnAwake = false;
		_shoots.loop = false;
	}
	
	void	FixedUpdate()
	{
		
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("buuton 0");
			_shoots.clip = _sounds[0];
			_shoots.Play();
			_gunshootParticles.GetComponent<Transform>().position = transform.position;
			_gunshootParticles.Play();
			HitPoint();
		}
		if (Input.GetMouseButtonDown(1) && ammo > 0)
		{
			Debug.Log("buuton 1");
			_shoots.clip = _sounds[1];
			_shoots.Play();
			_misileshootParticles.GetComponent<Transform>().position = transform.position;
			_misileshootParticles.Play();
			HitPoint();
			ammo -= 1;
		}
		Debug.DrawRay(transform.position, transform.forward * 250, Color.blue);
	}

	void	HitPoint()
	{
		LayerMask layer = LayerMask.GetMask("Battleground", "Ennemis");
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, 250f, layer))
			{
				_impactshootParticles.GetComponent<Transform>().position = hit.point;
				_impactshootParticles.Play();
				_shoots.clip = _sounds[2];
				_shoots.Play();
				// if (hit.collider.name == "Cube_1")
				// {
				// 	RaycastHit.transform.gameObject.GetComponent
				// }
			}
	}
}
