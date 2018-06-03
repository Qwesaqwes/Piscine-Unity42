using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public GameObject	player;

	private Vector3		_originPos;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		if (player)
		{
			_originPos = player.transform.position;
			_originPos.z = transform.position.z;
			transform.position = _originPos;
		}
	}
}
