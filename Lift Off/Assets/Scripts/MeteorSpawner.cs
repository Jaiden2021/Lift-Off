using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorSpawner : MonoBehaviour {

	public GameObject MeteorPrefab;      //Original Meteor Code
	public GameObject BlueMeteorPrefab;
	public GameObject FrontPlanePrefab;
	public GameObject BackPlanePrefab;

	float MeteorTimer = 0;
	float BlueMeteorTimer = 0;
	float FrontPlaneTimer = 0;
	float BackPlaneTimer = 0;

	float TimerReset = 0;



	public AudioSource WindStreak;
	public AudioSource SloMo;
	public GameObject RechargeBar;
	public float difficulty = 1.0f;
	int numMeteors = 0;

	public float minDelay;
	public float maxDelay;

	float spawnDelay;
	float lastSpawnTime;

	float slowdownEnergy;
	float maxEnergy = 5f;

	private int enemyClass = 0; 

	// Use this for initialization
	void Start () {
		slowdownEnergy = maxEnergy; //Slo Mo mechanic full energy
		lastSpawnTime = 0;
		spawnDelay = Random.Range(minDelay, maxDelay);
		WindStreak = GetComponent<AudioSource> ();
		//RechargeBar = GetComponent<GameObject> ();    //Recharge bar trial

	}

	// Update is called once per frame
	void Update () {

		MeteorTimer += Time.deltaTime;
		BlueMeteorTimer += Time.deltaTime;
		FrontPlaneTimer += Time.deltaTime;
		BackPlaneTimer += Time.deltaTime;


		
		/*if (Time.time - lastSpawnTime > spawnDelay) {




			/*lastSpawnTime = Time.time;
			spawnDelay = Random.Range(minDelay, maxDelay);

			if (numMeteors%10 == 0) {
				difficulty += .1f;
			}
		}*/
			if (MeteorTimer >= Random.Range (.35f, .7f)|| MeteorTimer >= .7f) {

				Vector2 spawnPosition = new Vector2 (Random.Range (-2.9f, 3.5f), 10);
				WindStreak.Play ();
				GameObject Meteor = Instantiate (MeteorPrefab, spawnPosition, Quaternion.identity) as GameObject;
				Meteor.GetComponent<Rigidbody2D> ().gravityScale = difficulty;
				numMeteors++;
				MeteorTimer = TimerReset;
			}

			if (BlueMeteorTimer >= Random.Range (3f, 6f)|| BlueMeteorTimer >= 6f ) {

				Vector2 spawnPosition = new Vector2 (Random.Range (-2.9f, 3.5f), 10);
				WindStreak.Play ();
				GameObject BlueMeteor = Instantiate (BlueMeteorPrefab, spawnPosition, Quaternion.identity) as GameObject;
				BlueMeteor.GetComponent<Rigidbody2D> ().gravityScale = difficulty;
				numMeteors++;
				BlueMeteorTimer = TimerReset;
			}

		if (FrontPlaneTimer >= Random.Range (1.5f, 3f)|| FrontPlaneTimer >= 3f ) {

			Vector2 spawnPosition = new Vector2 (Random.Range (-2.9f, 3.5f), 10);
			WindStreak.Play ();
			GameObject FrontPlane = Instantiate (FrontPlanePrefab, spawnPosition, Quaternion.identity) as GameObject;
			FrontPlane.GetComponent<Rigidbody2D> ().gravityScale = difficulty;
			numMeteors++;
			FrontPlaneTimer = TimerReset;
		}

		if (BackPlaneTimer >= Random.Range (2f, 4f)|| BackPlaneTimer >= 4f ) {

			Vector2 spawnPosition = new Vector2 (Random.Range (-2.9f, 3.5f), 10);
			WindStreak.Play ();
			GameObject BackPlane = Instantiate (BackPlanePrefab, spawnPosition, Quaternion.identity) as GameObject;
			BackPlane.GetComponent<Rigidbody2D> ().gravityScale = difficulty;
			numMeteors++;
			BackPlaneTimer = TimerReset;
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
				//Currently at full speed

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
					//Future: Add sound effect to indicate player doesn't have enough energy to restart the slowdown yet

			

				}

			} else if (Input.GetKeyUp (KeyCode.Space)) {
				//speed back up
				Time.timeScale = 1.0F;
			}
			
		}



}
