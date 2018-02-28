using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

	public GameObject MeteorPrefab;

	public float minDelay;
	public float maxDelay;

	float spawnDelay;
	float lastSpawnTime;

	// Use this for initialization
	void Start () {
		lastSpawnTime = 0;
		spawnDelay = Random.Range(minDelay, maxDelay);
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - lastSpawnTime > spawnDelay) {
			// spawn a new meteor
			SpawnMeteor();

			lastSpawnTime = Time.time;
			spawnDelay = Random.Range(minDelay, maxDelay);


		}
	}

	void SpawnMeteor () {
		Vector2 spawnPosition = new Vector2(Random.Range(-2.9f, 3.5f), 10);
		Instantiate(MeteorPrefab, spawnPosition, Quaternion.identity);
	}

}
