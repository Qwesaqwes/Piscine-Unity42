using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {
	private bool isClosed;
	private Vector3 initialPos;
	public bool isOnXAxis;

	// Use this for initialization

	void Start ()
	{
		isClosed = true;
		initialPos = transform.position;
	}
	
	void doorAnimation(float posDiff, bool newStatus)
	{
		Vector3 newPos = transform.position;
		if (isOnXAxis)
			newPos.x = newPos.x + posDiff;
		else
			newPos.y = newPos.y + posDiff;
		transform.position = newPos;
		isClosed = newStatus;
		Debug.Log(isClosed);
	}

	// Update is called once per frame
	void Update ()
	{
		float distance = Vector2.Distance(Camera.main.gameObject.transform.position, transform.position);
		if (Input.GetKeyDown(KeyCode.Q) && distance < 1.4) {
			if (isClosed == true) {
				doorAnimation(0.5f, !isClosed);
			} else {
				doorAnimation(-0.5f, !isClosed);
			}
		}
	}
}
