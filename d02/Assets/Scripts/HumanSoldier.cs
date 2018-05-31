using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSoldier : MonoBehaviour
{
	public GameObject	humanSoldier;
	private Vector2		_target;
	private bool		_move = false;
	private Animator	_anim;
	public AudioClip[]	sounds;
	public int			number_of_sounds;
	private AudioSource _HumanKnowledge;

	// Use this for initialization
	void Start ()
	{
		_anim = gameObject.GetComponent<Animator>();
		_HumanKnowledge = gameObject.AddComponent<AudioSource>();
		_HumanKnowledge.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetMouseButtonDown(0))
		{
			_target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (_move == false)
				_move = true;
			movement();
			_HumanKnowledge.clip = sounds[Random.Range(0, sounds.Length - 1)];
			_HumanKnowledge.Play();
		}
		if (_move)
		{
			transform.position = Vector3.MoveTowards(transform.position, _target, 2 * Time.deltaTime);
			if (transform.position.x == _target.x && transform.position.y == _target.y)
				idle();
		}
	}

	private float angleBetweenVector2(Vector2 vec1, Vector2 vec2)
	{
		Vector2 difference = vec2 - vec1;
		float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
		return (Vector2.Angle(Vector2.right, difference) * sign);
	}

	private void movement()
	{
		float angleBetween;
		
		angleBetween = angleBetweenVector2(transform.position, _target);
		if (angleBetween > 70 && angleBetween <= 110)
			resetIdle(0); // up
		else if (angleBetween > 20 && angleBetween <= 70)
			resetIdle(1); // right up
		else if (angleBetween <= 20 && angleBetween >= -20)
			resetIdle(2); // right
		else if (angleBetween < -20 && angleBetween > -70)
			resetIdle(3); // right down
		else if (angleBetween <= -70 && angleBetween > -110)
			resetIdle(4); // down
		else if (angleBetween > -160 && angleBetween < -110)
			resetIdle(5); // left down
		else if (angleBetween >= 160 && angleBetween < 180 || angleBetween >= -180 && angleBetween <= -160)
			resetIdle(6); // left
		else if (angleBetween > 110 && angleBetween < 160)
			resetIdle(7); // left up
	}

	private void resetIdle(int direction)
	{
		_anim.SetInteger("Idle", -1);
		_anim.SetInteger("State", direction);
	}

	private void idle()
	{
		int type = _anim.GetInteger("State");
		_anim.SetInteger("State", -1);
		if (type == 0)
			_anim.SetInteger("Idle", 0);
		else if (type == 1)
			_anim.SetInteger("Idle", 1);
		else if (type == 2)
			_anim.SetInteger("Idle", 2);
		else if (type == 3)
			_anim.SetInteger("Idle", 3);
		else if (type == 4)
			_anim.SetInteger("Idle", 4);
		else if (type == 5)
			_anim.SetInteger("Idle", 5);
		else if (type == 6)
			_anim.SetInteger("Idle", 6);
		else if (type == 7)	
			_anim.SetInteger("Idle", 7);
	}
}
