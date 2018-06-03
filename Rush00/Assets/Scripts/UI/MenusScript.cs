using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	public void onPlayClick() {
		Debug.Log("START GAME (CALLED FROM MENU)");
		SceneManager.LoadScene("map_00");
	}
	
	public void onExitClick() {
		Debug.Log("EXIT GAME (CALLED FROM MENU)");
		Application.Quit();
	}

	public void onResumeClick() {
		Debug.Log("RESUME GAME (CALLED FROM MENU)");
	}

	public void callWonMenu() {
		Debug.Log("wonMenu (CALLED FROM MENU)");
		SceneManager.LoadScene("wonMenu");		
	}

	public void callLostMenu() {
		Debug.Log("lostMenu (CALLED FROM MENU)");
		SceneManager.LoadScene("LostMenu");		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
