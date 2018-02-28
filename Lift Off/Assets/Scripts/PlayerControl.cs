using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float timer = 0;


	public Text timerText;

	public KeyCode rightKey;
	public KeyCode leftKey;

	public float speed;

	Vector2 moveDirection = Vector2.zero;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		moveDirection *= 0.8f;

		if (Input.GetKey(rightKey)) {
			moveDirection += Vector2.right;
		}

		if (Input.GetKey(leftKey)) {
			moveDirection += Vector2.left;
		}

		if(timerText != null){
			timerText.text = Mathf.Floor(timer * 100f).ToString ();
			Score.gameScore = (int)Mathf.Floor (timer);
		}
		Debug.Log (timer);
	}

	void FixedUpdate () {
		Vector2 position = (Vector2)transform.position + (moveDirection * speed * Time.fixedDeltaTime);
		rb.MovePosition(position);
	}

	void OnCollisionEnter2D(Collision2D other){                       //Setting up if statement for when balloon collides with enemy

		if (other.gameObject.tag == "Enemy") {

			Debug.Log ("!");
			SceneManager.LoadScene ("EndScreen", LoadSceneMode.Single);
		}
	}
}
	