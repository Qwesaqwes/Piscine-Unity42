using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	private GameObject	hp;
	private	gameManager	_player;
	private	Text		_textLife;
	private Text		_textEnergy;
	private ItemDragHandler	_itemDragedTower1;
	private ItemDragHandler	_itemDragedTower2;
	private ItemDragHandler	_itemDragedTower3;

	// Use this for initialization
	void Start ()
	{
		_player = GameObject.Find("GameManager").GetComponent<gameManager>();
		_textLife = GameObject.Find("TextLife").GetComponent<Text>();
		_textEnergy = GameObject.Find("TextEnergy").GetComponent<Text>();
		_itemDragedTower1 = GameObject.Find("ImageTower1").GetComponent<ItemDragHandler>();
		_itemDragedTower2 = GameObject.Find("ImageTower2").GetComponent<ItemDragHandler>();
		_itemDragedTower3 = GameObject.Find("ImageTower3").GetComponent<ItemDragHandler>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		_textLife.text = _player.playerHp.ToString();
		checkTowerUP();
		if (checkEnergyForTower() == 1)
		{
			energyDrain();
			_textEnergy.text = _player.playerEnergy.ToString();
		}
	}

	void checkTowerUP()
	{
		if (_player.playerEnergy >= 100)
		{
			_itemDragedTower1.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
			_itemDragedTower1.enableDrag = true;
			_itemDragedTower2.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
			_itemDragedTower2.enableDrag = true;
			_itemDragedTower3.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
			_itemDragedTower3.enableDrag = true;
		}
		if (_player.playerEnergy >= 80)
		{
			_itemDragedTower1.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
			_itemDragedTower1.enableDrag = true;
			_itemDragedTower2.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
			_itemDragedTower2.enableDrag = true;
		}
		if (_player.playerEnergy >= 50)
		{
			_itemDragedTower2.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
			_itemDragedTower2.enableDrag = true;
		}
	}

	int checkEnergyForTower()
	{
			// Debug.Log(_itemDragedTower1.energyOfTower);
		if (_player.playerEnergy < 50)
		{
			_itemDragedTower1.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
			_itemDragedTower1.enableDrag = false;
			_itemDragedTower2.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
			_itemDragedTower2.enableDrag = false;
			_itemDragedTower3.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
			_itemDragedTower3.enableDrag = false;
			return 0;
		}
		if (_player.playerEnergy < 80)
		{
			_itemDragedTower1.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
			_itemDragedTower1.enableDrag = false;
			_itemDragedTower3.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
			_itemDragedTower3.enableDrag = false;
			return 0;
		}
		if (_player.playerEnergy < 100)
		{
			_itemDragedTower3.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
			_itemDragedTower3.enableDrag = false;
			return 0;
		}
		
		// if (_itemDragedTower1.energyOfTower > _player.playerEnergy)
		// {
		// 	_itemDragedTower1.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
		// 	_itemDragedTower1.enableDrag = false;
		// 	_itemDragedTower3.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
		// 	_itemDragedTower3.enableDrag = false;
			
		// 	return 0;
		// }
		// if (_itemDragedTower2.energyOfTower > _player.playerEnergy)
		// {
		// 	_itemDragedTower1.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
		// 	_itemDragedTower1.enableDrag = false;
		// 	_itemDragedTower2.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
		// 	_itemDragedTower2.enableDrag = false;
		// 	_itemDragedTower3.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
		// 	_itemDragedTower3.enableDrag = false;
		// 	return 0;
		// }
		// if (_itemDragedTower3.energyOfTower > _player.playerEnergy)
		// {
		// 	_itemDragedTower3.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
		// 	_itemDragedTower3.enableDrag = false;
		// 	return 0;
		// }
		return 1;
	}

	void energyDrain()
	{
		if (_itemDragedTower1.energyOfTower != 0)
		{
			_player.playerEnergy -= _itemDragedTower1.energyOfTower;	
			_itemDragedTower1.energyOfTower = 0;
			// Debug.Log(_itemDragedTower1.energyOfTower);
		}
		else if (_itemDragedTower2.energyOfTower != 0)
		{
			_player.playerEnergy -= _itemDragedTower2.energyOfTower;	
			_itemDragedTower2.energyOfTower = 0;
		}
		else if (_itemDragedTower3.energyOfTower != 0)
		{
			_player.playerEnergy -= _itemDragedTower3.energyOfTower;	
			_itemDragedTower3.energyOfTower = 0;
		}
	}
}