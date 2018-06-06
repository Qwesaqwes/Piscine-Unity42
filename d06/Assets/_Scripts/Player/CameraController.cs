using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private PlayerController	_player;
    private float				vertical = 0.0f;
    private float				horizontal = 0.0f;
	private float				_cameraAngleSpeed = 2f;
	public float				_cameraH = 2;
	[SerializeField] private AudioClip			_keypickup;
	private AudioSource			_key;
	private bool				_ontime = false;
	// Use this for initialization
	void Start ()
	{
		_player = GameObject.Find("Player").GetComponent<PlayerController>();
		_key = gameObject.AddComponent<AudioSource>();
		_key.playOnAwake = false;
		_key.loop = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		vertical += _cameraAngleSpeed * Input.GetAxis("Mouse X");
		horizontal -= _cameraAngleSpeed * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(horizontal, vertical - 90, 0.0f);
		transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + _cameraH, _player.transform.position.z);
		if (_player._playerHaveKey && _ontime == false)
		{
			_key.clip = _keypickup;
			_key.Play();
			_ontime = true;
		}
	}
}
