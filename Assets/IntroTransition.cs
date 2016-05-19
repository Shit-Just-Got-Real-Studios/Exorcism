using UnityEngine;
using System.Collections;

public class IntroTransition : MonoBehaviour {

	public int index;
	void Start () {
	
	}
	
	void Update () {
		if (Time.timeSinceLevelLoad >= 2.5f)
			AutoFade.LoadLevel (index, 2, 3, Color.black);
	}
}
