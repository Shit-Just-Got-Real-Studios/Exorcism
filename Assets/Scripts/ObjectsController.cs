using UnityEngine;
using System.Collections;

public class ObjectsController : MonoBehaviour {
	private bool beginChutiyap;
	[SerializeField]
	private GameObject ZombieMain;
	void Start () {
	
	}
	void FixedUpdate () {
		Teleport controller = ZombieMain.GetComponent<Teleport> ();
		if (controller.score >= 7)
			beginChutiyap = true;
		if (beginChutiyap) {
			Vector3[] array = {
				transform.forward,
				transform.right,
				transform.up,
				-transform.forward,
				-transform.right,
				-transform.up
			};
			int randIndex = Random.Range (0, 6);
			GetComponent<Rigidbody> ().AddForce (array [randIndex] * 300);
			GetComponent<Rigidbody> ().AddForce (Physics.gravity * GetComponent<Rigidbody> ().mass);
		}
	}
}
