using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	private GameController gameController;

	[SerializeField]
	private int scoreValue;

	void Start () {
		var gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		Debug.Assert(gameController != null);
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Boundary") {
			return;
		}
		if (other.tag == "Player") {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();

		}
		Instantiate(explosion, transform.position, transform.rotation);
		Destroy(other.gameObject);
		Destroy(gameObject);
		gameController.AddScore(scoreValue);
	}
}
