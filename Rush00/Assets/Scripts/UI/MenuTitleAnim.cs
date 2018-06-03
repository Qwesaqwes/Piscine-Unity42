using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTitleAnim : MonoBehaviour {
	public const float topLimit = 0.07f;
	public const float botLimit = -0.07f;
	private int direction = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float zRotation = transform.rotation.z;
		if (zRotation >= topLimit || zRotation <= botLimit)
			direction *= -1;
		transform.Rotate(new Vector3(0, 0, 5 * direction * Time.deltaTime));
	}
}
