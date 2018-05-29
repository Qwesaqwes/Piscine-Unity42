using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerScript_ex00 : MonoBehaviour
{
	public GameObject[]	player;
	private static int	selectedPlayer = 0;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		choosePlayer();
		if (Input.GetKey("left"))
		{
			player[selectedPlayer].transform.position = new Vector3(player[selectedPlayer].transform.position.x - 0.1f, player[selectedPlayer].transform.position.y, 0);
		}
		if (Input.GetKey("right"))
		{
			player[selectedPlayer].transform.position = new Vector3(player[selectedPlayer].transform.position.x + 0.1f, player[selectedPlayer].transform.position.y, 0);
		}
		if (Input.GetKeyDown("space"))
		{
			player[selectedPlayer].GetComponent<Rigidbody2D>().AddForce(new Vector2(0,5), ForceMode2D.Impulse);
		}
	}

	private void choosePlayer()
	{
		if (Input.GetKeyDown("1"))
			selectedPlayer = 0;
		else if (Input.GetKeyDown("2"))
			selectedPlayer = 1;
		else if (Input.GetKeyDown("3"))
			selectedPlayer = 2;
		else if (Input.GetKeyDown("r"))
		{
			selectedPlayer = 0;
			Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

		}
	}
}
