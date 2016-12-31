using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour {

	private Rigidbody rb;

	public float speed;
	void Start () {
		rb = GetComponent<Rigidbody>();

		//var moveUp = new Vector3(0.0f, 0.0f, 10);
		rb.velocity = transform.forward * speed;
	}
}
