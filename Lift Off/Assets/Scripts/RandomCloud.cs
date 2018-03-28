using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCloud : MonoBehaviour {

	public Transform[] clouds;

	private float randomTimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		randomTimer -= Time.deltaTime;

		if(randomTimer <= 0){
			Instantiate (clouds[Random.Range(0, 7)]);
			randomTimer = Random.Range (1.25f, 2.5f);
		}
	}
}
