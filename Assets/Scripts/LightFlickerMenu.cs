using UnityEngine;
using System.Collections;

public class LightFlickerMenu : MonoBehaviour {

	[SerializeField]
	private GameObject lampLight;

	[SerializeField]
	private Light lt;

	public float duration = 1.0F;
	             
	void Update () {
		float time1 = Time.timeSinceLevelLoad;

		if (time1 >= 2.0f && time1 <= 4f) {
			float phi = Time.timeSinceLevelLoad / duration * 3 * Mathf.PI;
			float amplitude = Mathf.Cos (phi);
			if (Mathf.Abs(amplitude) >= (0.5f)) {
				lt.intensity = 8f;
			} else {
				lt.intensity = 0f;
			}
		}

			
		if (time1 >= 4.0f) {
			lampLight.SetActive(true);
			lt.intensity = 3.2f;
		}
	}
}
