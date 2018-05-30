using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
	public GameObject		platform;
	public float			range;
	public float			delay;
	private float	_startingPoint = 0.0f;
	private int		_sign = 1;
	private float	_pos;
	private float	_neg;

	void Start()
	{
		_startingPoint = transform.position.y;
		_pos = _startingPoint + range;
		_neg = _startingPoint - range;
		StartCoroutine(fade());
	}

	// Update is called once per frame
	void Update ()
	{
		// fade();
		if (Mathf.Clamp(transform.position.y, _neg, _pos) == _neg)
			_sign = 1;
		else if (Mathf.Clamp(transform.position.y, _neg, _pos) == _pos)
			_sign = -1;
		transform.Translate(Vector3.up * Time.deltaTime * _sign);
	}

	private IEnumerator fade()
	{
		yield return new WaitForSeconds(delay);
	}
}


