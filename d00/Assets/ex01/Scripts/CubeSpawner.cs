using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
	public GameObject[] cube;
	private static float timer;
	private static float spawntime;
	public static float min = 0.5F;
	public static float max = 1.0F;

	void start()
	{
		spawntime = Random.Range(min, max);
		timer = 0;
	}

	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= spawntime)
		{
			int index = Random.Range(0, cube.Length);
			Instantiate(cube[index], cube[index].transform.position, Quaternion.identity);
			timer = 0;
			spawntime = Random.Range(min, max);
		}
	}
}
