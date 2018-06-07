using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGunRotation : MonoBehaviour
{
	public float _turretSpeedRotation = 100f;
	[SerializeField] private Transform tankBase;
	[SerializeField] private GameObject camobj;
	private Camera cam;

	// Use this for initialization
	void Start ()
	{
		cam = camobj.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3 (tankBase.position.x, tankBase.position.y + 1.6f, tankBase.position.z);
		Vector3 mousePos = cam.ScreenToViewportPoint(Input.mousePosition);
		if (mousePos.x < 0.45f)
			transform.Rotate(0, 0, -1 * _turretSpeedRotation);
		if (mousePos.x > 0.55f)
			transform.Rotate(0, 0, _turretSpeedRotation);


		// int layerMask = 9;
		// RaycastHit hit;
		// if (Physics.Raycast(transform.position, Vector3.down, out hit, 250f, layerMask))
		// {
		// 	if (hit.collider.tag == "Battleground")
		// 	{
		// 		Debug.Log("You Hit Battleground");
		// 	}
			
		// }
		// Debug.DrawRay(transform.position, transform.forward * 250, Color.blue);
	}
}
