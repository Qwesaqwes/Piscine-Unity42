using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseObj : MonoBehaviour
{
	public GameObject box;
	public float		largeur;
	public float		hauteur;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		other.transform.localScale = new Vector3(largeur, hauteur, 0);
	}
}
