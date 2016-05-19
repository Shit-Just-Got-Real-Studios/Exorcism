using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ToggleVR : MonoBehaviour {

	public void ToggleVRMode() {
		AutoFade.LoadLevel(3 , 2, 3, Color.black);;
	}

	public void ToggleARMode() {
		AutoFade.LoadLevel(4 , 2, 3, Color.black);;
	}
}
