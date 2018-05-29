using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public Club newClub;
	public SpriteRenderer ball;
	private static bool _movement = false;
	private static bool _sign = false;
	private static float	_HitPower = 1;
	private static int _score = -15;

	// Update is called once per frame
	 void Update ()
	{
		if (_HitPower > 0 && _movement)
		{
			if (Mathf.Clamp(ball.transform.position.y, -4.5f, 4.5f) == 4.5f)
				_sign = true;
			else if (Mathf.Clamp(ball.transform.position.y, -4.5f, 4.5f) == -4.5f)
				_sign = false;

			if (_sign == false)
				ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y + (0.2f * _HitPower), 0);
			else
				ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y - (0.2f * _HitPower), 0);

			if (ball.transform.position.y > 2.20f && ball.transform.position.y < 2.80f && _HitPower > 0 && _HitPower < 0.2f)
			{
				Debug.Log("GJ!!");
				_score = -20;
				ball.transform.position = new Vector3(0, -3.5f, 0);
				_HitPower = 0;
			}
			_HitPower -= 0.1f;
			initclub();
		}
	}

	private void initclub()
	{
		if (_HitPower <= 0)
		{
			if (ball.transform.position.y > 3.20f && ball.transform.position.y < 4.5f)
				_sign = true;
			else
				_sign = false;
			
			_movement = false;
			_HitPower = 0;
			_score += 5;
			Debug.Log("Score: " + _score);
			if (_score >= 0)
				Debug.Log("Looser, but you can play more if you want :D");
			newClub.reenable();
		}
	}

	public void initBallClass(float HitPower)
	{
		_HitPower = HitPower;
		_movement = true;
	}
}
