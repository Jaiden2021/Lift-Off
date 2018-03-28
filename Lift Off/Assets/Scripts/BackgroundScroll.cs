using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

	public float speed;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x, transform.position.y - speed * Time.deltaTime);

		if (transform.position.y < -260f) {
			transform.position = new Vector2 (transform.position.x, -5f);
		}

	}

}
