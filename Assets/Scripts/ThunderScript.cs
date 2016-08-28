using UnityEngine;
using System.Collections;

public class ThunderScript : MonoBehaviour {
	[SerializeField]
	private GameObject demon;
	[SerializeField]
	private AudioClip[] demonSounds;
	void Start () {
			
	}
	
	void Update () {
		if (demon.GetComponent<Teleport> ().score >= 7) {
			if (gameObject.name == "_DemonSoundSystem" && ((int)Time.timeSinceLevelLoad % 9 == 0) && (Time.timeSinceLevelLoad - (int)Time.timeSinceLevelLoad <= 0.04f)) {
				if (GetComponent<AudioSource> ().isPlaying)
					goto A;
				else {
					GetComponent<AudioSource> ().Play ();
				}
				A:
				{}
			} else if (gameObject.name != "_DemonSoundSystem") {
				if (GetComponent<AudioSource> ().isPlaying)
					goto B;
				else {
					GetComponent<AudioSource> ().Play ();
				}
				B:
				{}
			}
		}
	}
}
