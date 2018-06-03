using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpawn : MonoBehaviour
{
	private PlayerMovement	_playerController;
	private Sprite[] 		_sprites;
	private Sprite[]		_bulletSprites;
	private Sprite[]		_weaponsSprites;
	public GameObject		pickUp;
	public GameObject		bullet;
	public GameObject		melee;
	private SpriteRenderer	_spriteRenderer;
	public int				weapon;

	public int 			amunition;

	// Use this for initialization
	void Start ()
	{
		_playerController = GameObject.Find("Character").GetComponent<PlayerMovement>();
		_sprites = Resources.LoadAll<Sprite>("Sprites/weapons/attach-to-body");
		_bulletSprites = Resources.LoadAll<Sprite>("Sprites/weapons/shoot");
		_weaponsSprites = Resources.LoadAll<Sprite>("Sprites/weapons/armas");
		Debug.Log(_weaponsSprites.Length);
		gameObject.AddComponent<SpriteRenderer>();
		_spriteRenderer = GetComponent<SpriteRenderer>();//.sprite = _sprites[_playerController.selectedWeapon - 1];
		weapon = _playerController.selectedWeapon;
		setWeaponAttachSprite(weapon.ToString());
		setAmunition(weapon);

		Vector3 tmp = transform.parent.position;
		tmp.x += 0.179f;
		tmp.y += 0.334f;
		transform.position = tmp;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(1))
		{
			var tmp1 = Instantiate(pickUp, _playerController.transform.position, Quaternion.identity);
			for (int j = 0; j < _sprites.Length; j++)
			{
				if (_sprites[j].name == weapon.ToString())
				{
					tmp1.GetComponent<SpriteRenderer>().sprite = _weaponsSprites[j];
					break;
				}
			}
			_playerController.weaponPicked = false;
			Destroy(gameObject);
		}
		else if (Input.GetMouseButtonDown(0))
		{
			if (weapon == 5 || weapon == 12)
			{	
				var tmp2 = Instantiate(melee, _playerController.transform.position, Quaternion.identity);
				tmp2.AddComponent<SpriteRenderer>();
				for (int j = 0; j < _sprites.Length; j++)
				{
					if (_sprites[j].name == weapon.ToString())
					{
						tmp2.GetComponent<SpriteRenderer>().sprite = _bulletSprites[j];
						break;
					}
				}
			}
			else if ((weapon != 5 || weapon != 12) && amunition > 0)
			{
				var tmp3 = Instantiate(bullet, _playerController.transform.position, Quaternion.identity);
				tmp3.AddComponent<SpriteRenderer>();
				for (int j = 0; j < _sprites.Length; j++)
				{
					if (_sprites[j].name == weapon.ToString())
					{
						tmp3.GetComponent<SpriteRenderer>().sprite = _bulletSprites[j];
						break;
					}
				}
				amunition--;
			}
			Debug.Log("Ammo: " + amunition);
		}

	}

	void setWeaponAttachSprite(string i)
	{
		for (int j = 0; j < _sprites.Length; j++)
		{
			if (_sprites[j].name == i)
			{
				_spriteRenderer.sprite = _sprites[j];
				break;
			}
		}
	}

	void setAmunition(int weapon)
	{
		if (weapon == 3 || weapon == 6 || weapon == 7 || weapon == 4)
			amunition = 5;
		else if (weapon == 2 || weapon == 8 || weapon == 10)
			amunition = 8;
		else if (weapon == 1 || weapon == 9 || weapon == 11)
			amunition = 20;
	}
}
