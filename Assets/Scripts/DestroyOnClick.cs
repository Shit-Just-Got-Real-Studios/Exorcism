using UnityEngine;
using System.Collections;

public class DestroyOnClick : MonoBehaviour {
	//This sucks
	void OnClick() {
		Destroy (gameObject);
		Debug.Log ("Ha bhai");
	}
}
