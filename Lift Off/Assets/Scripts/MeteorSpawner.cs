using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

	public GameObject MeteorPrefab;
	public AudioSource WindStreak;
	public float difficulty = 1.0f;
	int numMeteors = 0;

	public float minDelay;
	public float maxDelay;

	float spawnDelay;
	float lastSpawnTime;

	// Use this for initialization
	void Start () {
		lastSpawnTime = 0;
		spawnDelay = Random.Range(minDelay, maxDelay);
		WindStreak = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - lastSpawnTime > spawnDelay) {
			// spawn a new meteor
			SpawnMeteor();

			lastSpawnTime = Time.time;
			spawnDelay = Random.Range(minDelay, maxDelay);

			if (numMeteors%10 == 0) {
				difficulty += .1f;
			}

		}
	}

	void SpawnMeteor () {
		
		//randomPrefab = random number from 1 - 7
		// if number = 1, ourgameobject = cloud1
		//if number = 2, ourgameobject = cloud2
		Vector2 spawnPosition = new Vector2(Random.Range(-2.9f, 3.5f), 10);
		WindStreak.Play ();
		GameObject Meteor = Instantiate(MeteorPrefab, spawnPosition, Quaternion.identity) as GameObject;
		Meteor.GetComponent<Rigidbody2D> ().gravityScale = difficulty;
		numMeteors++;
	}


}
