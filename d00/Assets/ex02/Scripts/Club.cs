using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
	public Ball ball;
	public SpriteRenderer GolfStick;
	public float HitPower = 0;
	private static float	_speedClub = 0.2f;
   
    // Use this for initialization
    void Start ()
	{
		GolfStick.transform.position = new Vector3(ball.transform.position.x - 0.2f, ball.transform.position.y, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Flip Club if above hole
		if (ball.transform.position.y >= 3.2f)
			GolfStick.flipY = true;
		else
			GolfStick.flipY = false;

		//Movement of Ball
		if (HitPower > 0 && Input.GetKey("space") == false)
		{
			GolfStick.transform.position = new Vector3(ball.transform.position.x - 0.2f, ball.transform.position.y, 0);
			ball.initBallClass(HitPower);
			enabled = false;
		}

		//Movement of club
		if (Input.GetKey("space") && GolfStick.flipY != true)
		{
			HitPower += 0.2f;
			GolfStick.transform.position = new Vector3(GolfStick.transform.position.x, GolfStick.transform.position.y - _speedClub, 0);
		}
		else if (Input.GetKey("space") && GolfStick.flipY == true)
		{
			HitPower += 0.2f;
			GolfStick.transform.position = new Vector3(GolfStick.transform.position.x, GolfStick.transform.position.y + _speedClub, 0);
		}
	}

	public void	reenable()
	{
		HitPower = 0;
		GolfStick.transform.position = new Vector3(ball.transform.position.x - 0.2f, ball.transform.position.y, 0);
		enabled = true;
	}
}
