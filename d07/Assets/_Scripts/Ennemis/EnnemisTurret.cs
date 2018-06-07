using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemisTurret : MonoBehaviour
{
	[SerializeField] ParticleSystem _impactshootParticles;
	[SerializeField] AudioClip		_sounds;
	public GameObject				_Patrol;
	AudioSource						_impactSound;
	float nextFire = 0f;
	float fireRate = 3f;

	// Use this for initialization
	void Start ()
	{
		_impactSound = gameObject.AddComponent<AudioSource>();
		_impactSound.loop = false;
		_impactSound.playOnAwake = false;
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		LayerMask layer = LayerMask.GetMask("Tank", "Battleground", "Ennemis");
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, 50f, layer))
		{
			if (hit.collider != null)
			{
				if (hit.collider.tag == "Player" && Time.time > nextFire)
				{
					Debug.Log("player detected");
					nextFire = Time.time + fireRate;
					_impactshootParticles.GetComponent<Transform>().position = hit.point;
					_impactshootParticles.Play();
					_impactSound.clip = _sounds;
					_impactSound.Play();
					// if (hit.distance < 25f)
					// 	_Patrol.GetComponent<NavMeshAgent>().isStopped = true;
					// else
					// 	_Patrol.GetComponent<NavMeshAgent>().isStopped = false;
				}
				if (hit.collider.tag == "Ennemi" && Time.time > nextFire)
				{
					Debug.Log("player detected");
					nextFire = Time.time + fireRate;
					_impactshootParticles.GetComponent<Transform>().position = hit.point;
					_impactshootParticles.Play();
					_impactSound.clip = _sounds;
					_impactSound.Play();
					// if (hit.distance < 25f)
					// 	_Patrol.GetComponent<NavMeshAgent>().isStopped = true;
					// else
					// 	_Patrol.GetComponent<NavMeshAgent>().isStopped = false;
				}
				// Debug.Log(hit.distance);
			
				// 	// stop ennemi
			}
		}
		Debug.DrawRay(transform.position, transform.forward * 50, Color.red);

	}
}
