using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResumeMenu : MonoBehaviour
{
	private	bool	GameIsPaused = false;
	public GameObject	pauseMenuUI;
	public GameObject	fanInfoUI;
	public GameObject	loseMenuUI;
	public GameObject	keyInfoUI;
	public GameObject	switchInfoUI;
	public GameObject	winMenuUI;
	public GameObject	introInfoUI;
	
	private FanActivation	_fan;
	private KeyCard			_key;
	private SwitchUnit		_switch;
	private PaperPick		_paper;
	private PlayerController _player;

	// Use this for initialization
	void Start ()
	{
		_fan = GameObject.Find("prop_fan_005").GetComponent<FanActivation>();
		_key = GameObject.Find("prop_keycard_card").GetComponent<KeyCard>();
		_switch = GameObject.Find("prop_switchUnit").GetComponent<SwitchUnit>();
		_paper = GameObject.Find("Plane").GetComponent<PaperPick>();
		_player = GameObject.Find("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
				Resume();
			else
				Pause();
		}
		if (_player.playerLose)
		{
			Time.timeScale = 0f;
			loseMenuUI.SetActive(true);
		}
		else if (_paper.playerWin)
		{
			Time.timeScale = 0f;
			winMenuUI.SetActive(true);
		}
		else
			Time.timeScale = 1f;

		if (_key.showKeyInfo)
			keyInfoUI.SetActive(true);
		else
			keyInfoUI.SetActive(false);
		if (_fan.playerEnter)
			fanInfoUI.SetActive(true);
		else
			fanInfoUI.SetActive(false);
		if (_switch.showSwitchInfo)
			switchInfoUI.SetActive(true);
		else
			switchInfoUI.SetActive(false);
		if (_player._intro == false)
			introInfoUI.SetActive(false);
		
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;;
	}

	void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void Restart()
	{
		SceneManager.LoadScene("ex00");
	}
}
