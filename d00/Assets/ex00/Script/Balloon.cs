using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
	public static float timer;
	public static int count = 0;
	public static float timeleft = 0.5F;

	void Update ()
		{
			timer = Time.time;
			if (Input.GetKeyDown("space") && count != 10)
			{
				count += 1;
				transform.localScale += new Vector3(0.5F, 0.5F, 0);
				if (transform.localScale.x >= 7 && transform.localScale.y >= 7)
				{
					Debug.Log("Baloon timer: " + Mathf.RoundToInt(timer));
					enabled = false;
				}
			}
			else if (transform.localScale.x > 0.1F && transform.localScale.y > 0.1)
			{
				transform.localScale -= new Vector3(0.1F, 0.1F, 0);
				if (count == 10)
				{
					timeleft -= Time.deltaTime;
					if (timeleft <= 0)
					{
						count = 0;
						timeleft = 0.5F;
					}
				}
			}
			else
			{
				Debug.Log("Baloon timer: " + Mathf.RoundToInt(timer));
				GameObject.Destroy(gameObject);
			}
			
		}
}
