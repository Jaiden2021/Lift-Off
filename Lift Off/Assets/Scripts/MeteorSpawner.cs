using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

	public GameObject MeteorPrefab;
	public AudioSource WindStreak;
	public AudioSource SloMo;
	public float difficulty = 1.0f;
	int numMeteors = 0;

	public float minDelay;
	public float maxDelay;

	float spawnDelay;
	float lastSpawnTime;

	float slowdownEnergy;
	float maxEnergy = 5f;

	// Use this for initialization
	void Start () {
		slowdownEnergy = maxEnergy; //full energy
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


		//handle slowdown timer
		if (Time.timeScale < 1.0f) {
			//slowed down
			//drain the energy

			slowdownEnergy -= Time.unscaledDeltaTime; //Normal time seconds even if time is scaled 
			if (slowdownEnergy <= 0) {
				slowdownEnergy = 0;
				Time.timeScale = 1.0f; 
				//Add back to full speed sound effect
			}
		} else {
			//we are at full speed
			//regenerate the energy

			slowdownEnergy += Time.deltaTime;
			if (slowdownEnergy >= maxEnergy) {
				slowdownEnergy = maxEnergy;
				//Add regeneration bar 
			
			}
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			//only allow a slowdown if energy is full
			if (slowdownEnergy >= maxEnergy) {
				//slow down
				Time.timeScale = 0.3F;
				SloMo.Play ();
			} else {
				//Add sound effect to indicate player doesn't have enough energy to restart the slowdown yet

			

			}

		} else if (Input.GetKeyUp (KeyCode.Space)) {
			//speed back up
			Time.timeScale = 1.0F;
		}

//		if (Input.GetKey(KeyCode.Space)) {
//			SloMo.Play ();
//
//			if (Time.timeScale == 1.0F) {
//				Time.timeScale = 0.3F;
//			} else {
//				Time.timeScale = 1.0F;
//			}
//			Time.fixedDeltaTime = 0.02F * Time.timeScale;
//
//		}
	}

	void SpawnMeteor () {
		
		Vector2 spawnPosition = new Vector2(Random.Range(-2.9f, 3.5f), 10);
		WindStreak.Play ();
		GameObject Meteor = Instantiate(MeteorPrefab, spawnPosition, Quaternion.identity) as GameObject;
		Meteor.GetComponent<Rigidbody2D> ().gravityScale = difficulty;
		numMeteors++;
	}


}
