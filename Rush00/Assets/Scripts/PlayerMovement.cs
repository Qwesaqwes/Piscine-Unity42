using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float		_playerSpeed = 10.0f;
	private Rigidbody2D	_playerRb2D;
	private Animator	_animation;
	public bool			weaponPicked = false;
	public GameObject	weaponAttach = null;
	public string		typeWeapon;
	public int			selectedWeapon = 0;
	// Use this for initialization
	void Start ()
	{
		_playerRb2D = GetComponent<Rigidbody2D>();
		_animation = GameObject.Find("CharacterLegAnimation").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		playerRotationToMouse();	//Function to rotate PJ where the mouse is
	}

	void FixedUpdate()				//All our physics calculations should be done in Fixed Update
	{
		playerMovement();			//Function to move and set animation;
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Weapon" && (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.E)) && weaponPicked == false)
		{
			Debug.Log("You entered trigger");
			Instantiate(weaponAttach, transform.GetChild(0));
			// Instantiate(weaponAttach, transform.localPosition);
			
			
			
			// weaponAttach.transform.position = transform.position;
			string typeWeapon = other.GetComponent<SpriteRenderer>().sprite.name; //get name of sprite of weapon
			if (typeWeapon == "1")
				selectedWeapon = 1;
			else if (typeWeapon == "2")
				selectedWeapon = 2;
			else if (typeWeapon == "3")
				selectedWeapon = 3;
			else if (typeWeapon == "4")
				selectedWeapon = 4;
			else if (typeWeapon == "5")
				selectedWeapon = 5;
			weaponPicked = true;
			Destroy(other.gameObject);
		}
	}

	void	playerMovement()
	{
		_playerRb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * _playerSpeed, Input.GetAxis("Vertical") * _playerSpeed);
		if (_playerRb2D.velocity.x != 0 || _playerRb2D.velocity.y != 0)
		{
			_animation.SetInteger("Idle", 0);
			_animation.SetInteger("Run", 1);
		}
		else
		{
			_animation.SetInteger("Run", 0);
			_animation.SetInteger("Idle", 1);
		}
	}
	void	playerRotationToMouse()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        mousePos.x = mousePos.x - transform.position.x;
        mousePos.y = mousePos.y - transform.position.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		angle +=90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
}
