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
	private int				weapon;

	private int 			amunition;

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

		// transform.position = _playerController.transform.position;
		// transform.position.x = 

		Vector3 tmp = transform.parent.position;
		tmp.x += 0.179f;
		tmp.y += 0.334f;
		transform.position = tmp;
		

		

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton(1))
		{
			var tmp = Instantiate(pickUp, _playerController.transform.position, Quaternion.identity);
			for (int j = 0; j < _sprites.Length; j++)
			{
				if (_sprites[j].name == weapon.ToString())
				{
					tmp.GetComponent<SpriteRenderer>().sprite = _weaponsSprites[j];
					break;
				}
			}
			_playerController.weaponPicked = false;
			Destroy(gameObject);
		}
		else if (Input.GetMouseButton(0))
		{
			if (weapon == 5 || weapon == 12)
			{
				var tmp = Instantiate(melee, _playerController.transform.position, Quaternion.identity);
				tmp.AddComponent<SpriteRenderer>();
				for (int j = 0; j < _sprites.Length; j++)
				{
					if (_sprites[j].name == weapon.ToString())
					{
						tmp.GetComponent<SpriteRenderer>().sprite = _bulletSprites[j];
						break;
					}
				}
			}
			else
			{
				var tmp = Instantiate(bullet, _playerController.transform.position, Quaternion.identity);
				tmp.AddComponent<SpriteRenderer>();
				for (int j = 0; j < _sprites.Length; j++)
				{
					if (_sprites[j].name == weapon.ToString())
					{
						tmp.GetComponent<SpriteRenderer>().sprite = _bulletSprites[j];
						break;
					}
				}
			}
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
}
