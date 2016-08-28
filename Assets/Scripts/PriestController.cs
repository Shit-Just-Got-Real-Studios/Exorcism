using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PriestController : MonoBehaviour {
	public float healthPacket = 100.0f;

	void ApplyDamage(float Damage) {
		healthPacket -= Damage;
	}

	void Update () {
		if (healthPacket <= 0.0f) {
			SceneManager.LoadScene (0);
		}
	}
}
