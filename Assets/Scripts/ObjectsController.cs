using UnityEngine;
using System.Collections;

public class ObjectsController : MonoBehaviour {
	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		InvokeRepeating ("AddForce", 2, 5);
	}

	void AddForce () {
		rb.AddExplosionForce (1.0f, transform.position, 2.0f);
	}
}
