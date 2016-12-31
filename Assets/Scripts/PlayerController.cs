using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bounds {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	private Rigidbody rigidBody;

	public Bounds bounds;
	public float speed;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn;

	public float shotRate;
	private float nextShotTime = 0.0f;
	
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		var movement = new Vector3(horizontal, 0.0f, vertical);

		rigidBody.velocity = movement * speed;

		rigidBody.position = new Vector3
		(
			Mathf.Clamp(rigidBody.position.x, bounds.xMin, bounds.xMax),
			0.0f,
			Mathf.Clamp(rigidBody.position.z, bounds.zMin, bounds.zMax)
		);

		rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);
	}

	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextShotTime) {
			nextShotTime = Time.time + shotRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
