using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
	public GameObject ball;
	public SpriteRenderer GolfStick;
	// private static int Score;
	public int HitPower;
    // private Ball newBall1;

    // public Ball NewBall { get; private set; }

    // Use this for initialization
    void Start ()
	{
		// Score = 15;
		HitPower = 0;
		GolfStick.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ball.transform.position.y > 3)
		{
			GolfStick.flipY = true;
		}
		if (Input.GetKey("space"))
		{
			HitPower += 1;
			GolfStick.transform.position = new Vector3(GolfStick.transform.position.x, (GolfStick.transform.position.y - 0.2f), 0);
			// NewBall = GolfStick.GetComponent<Ball>();
			// NewBall.initBallClass(HitPower);
		}
	}
}
