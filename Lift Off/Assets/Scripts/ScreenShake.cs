using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {
	private bool isShaking = false;
	private float baseX, baseY, baseZ;
	private float intensity = 0.1f;
	private int shakes = 0;






	// Use this for initialization
	void Start () {
		baseX = transform.position.x;
		baseY = transform.position.y;
		baseZ = transform.position.z;



	}
	void FixedUpdate () {
		


		if (isShaking) {
			float randomShakeX = Random.Range (-intensity, intensity);
			float randomShakeY = Random.Range (-intensity, intensity);

			transform.position = new Vector3 (baseX + randomShakeX, baseY + randomShakeY, baseZ);

			shakes--;

			if (shakes <= 0) {
				isShaking = false;
				transform.position = new Vector3 (baseX, baseY, baseZ);


				PlayerMechanics PM = GameObject.Find ("Player Balloon").GetComponent<PlayerMechanics> ();
				PM.HasShaken = true;
			} else {
				PlayerMechanics PM = GameObject.Find ("Player Balloon").GetComponent<PlayerMechanics> ();
				PM.HasShaken = false;
			}
		}
	}

	//Different Shakes
	public void MinorShake(float in_intensity) {
		isShaking = true;
		shakes = 10;
		intensity = in_intensity;
	}
}
