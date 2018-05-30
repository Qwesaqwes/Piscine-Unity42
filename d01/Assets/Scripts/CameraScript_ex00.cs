using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript_ex00 : MonoBehaviour
{
	public GameObject[]	player;
	private int	selectedPlayer = 0;
	
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		choosePlayer();
		transform.position = new Vector3(player[selectedPlayer].transform.position.x, player[selectedPlayer].transform.position.y, transform.position.z);
	}

	private void choosePlayer()
	{
		if (Input.GetKeyDown("1") || Input.GetKeyDown("r"))
			selectedPlayer = 0;
		else if (Input.GetKeyDown("2"))
			selectedPlayer = 1;
		else if (Input.GetKeyDown("3"))
			selectedPlayer = 2;
	}
}
 