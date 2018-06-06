using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float	_playerSpeed = 10f;
	[HideInInspector] public float 	_playerAngleSpeed = 2.0f;
	[HideInInspector] public bool		detected = false;
	[HideInInspector] public float			_detectionSpeed = 0;
	[HideInInspector] public bool				playerLose = false;
	[HideInInspector] public bool			_playerHaveKey = false;
	[HideInInspector] public AudioSource 	_walkingSound;
	[HideInInspector] public bool			_intro = true;
	private Slider	_Slider;
	private bool	_playerWalking = false;
	[SerializeField] private AudioClip[]		sounds;
	private AudioSource 	_PlayerSounds;
	private bool			_alarmSet = false;
	

	CameraController _camera;
	// Use this for initialization
	void Start ()
	{
		_camera = GameObject.Find("Main Camera").GetComponent<CameraController>();
		_Slider = GameObject.Find("Slider").GetComponent<Slider>();
		_walkingSound = GetComponent<AudioSource>();
		_PlayerSounds = gameObject.AddComponent<AudioSource>();
		_PlayerSounds.playOnAwake = false;
		_PlayerSounds.loop = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _camera.transform.localEulerAngles.y + 90, transform.localEulerAngles.z);
		var Haxis = Input.GetAxis("Horizontal");
		var Vaxis = Input.GetAxis("Vertical");
		if ((Haxis != 0 || Vaxis != 0) && _playerWalking == false)
		{
			_walkingSound.enabled = true;
			_walkingSound.Play();
			_playerWalking = true;
			_intro = false;
		}
		else if (Haxis == 0 && Vaxis == 0)
		{
			_walkingSound.enabled = false;
			_walkingSound.Stop();
			_playerWalking = false;
		}
		transform.Translate(new Vector3(Input.GetAxis("Vertical") * -1 * Time.deltaTime * _playerSpeed, 0, Input.GetAxis("Horizontal") * Time.deltaTime * _playerSpeed));
		if (detected)
		{
			if (_Slider.value >= 100)
			{
				_walkingSound.Stop();
				playerLose = true;
			}
			else if (_Slider.value > 75 && _alarmSet == false)
			{
				_PlayerSounds.clip = sounds[0];
				_PlayerSounds.Play();
				_alarmSet = true;
			}
			_Slider.value += _detectionSpeed;
		}
		else
		{
			if (_Slider.value < 75)
			{
				_PlayerSounds.Stop();
				_alarmSet = false;
			}
			if (_Slider.value > 0)
				_Slider.value -= _detectionSpeed;
		}
	}
}
