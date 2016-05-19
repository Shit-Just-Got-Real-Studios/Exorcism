using UnityEngine;
using System.Collections;

public class LaughSound : MonoBehaviour {
	private AudioSource laugh;
	private int count = 0;
	// Use this for initialization
	void Start () {
		laugh = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > 4.0f) {
			if (laugh.isPlaying)
				goto A;
			else {
				if (count == 0) 
					laugh.PlayOneShot (laugh.clip);
				count++;
			}
			A: {}
		}
	}
}
