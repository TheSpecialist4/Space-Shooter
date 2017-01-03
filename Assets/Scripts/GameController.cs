using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;

	public float spawnWait;

	public float startWait;

	public float waveWait;

	public int hazardCount;

	public GUIText scoreText;

	public GUIText restartText;

	public GUIText gameOverText;

	private bool gameOver;

	private bool restart;

	private int score;

	void Start () {
		score = 0;
		UpdateScore();
		StartCoroutine(SpawnWaves());

		gameOver = false;
		restart = false;

		restartText.text = "";
		gameOverText.text = "";
	}
	
	// IEnumerator used for coroutines
	IEnumerator SpawnWaves () {
		int waveCount = 2;
		yield return new WaitForSeconds(startWait);
		while (true) {
			gameOverText.text = "";
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 
						spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			gameOverText.text = "Wave " + waveCount++;
			yield return new WaitForSeconds(waveWait);
			hazardCount += 5;

			if (gameOver) {
				restartText.text = "Press 'R' for restart";
				gameOverText.text = "Game Over";
				restart = true;
				break;
			}
		}
	}

	public void AddScore(int scoreValue) {
		score += scoreValue;
		UpdateScore();
	}

	public void GameOver() {
		gameOver = true;
		gameOverText.text = "Game Over";
	}

	void UpdateScore () {
		scoreText.text = "Score: " + score;
	}

	void Update () {
		if (restart) {
			if (Input.GetKeyDown(KeyCode.R)) {
				//Application.LoadLevel(Application.loadedLevel);
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
}
