using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {
	[SerializeField]
	private int flickeringFrequency;

	[SerializeField]
	private GameObject lampLight;

	[SerializeField]
	private GameObject lampLightSpot;

	[SerializeField]
	private GameObject PossessedModel;

	[SerializeField]
	private GameObject FlyingDemonModel;

	[SerializeField]
	private Light lt;

	[SerializeField]
	private Light lt1;

	public bool flicker = false;
	public float duration = 1.0F;
	private AudioSource laugh;
	public bool teleport = false;
	private float counter = 0f;
	private bool hit = false;
	void Start() {
		laugh = GetComponent<AudioSource> ();
	}
	             
	void Update () {
		float time1 = Time.timeSinceLevelLoad;
		if (time1 > 4.0f && time1 < 12.0f) {
			PossessedModel.transform.Translate (Vector3.up * -Time.deltaTime * 1.5f);
		}
		if (Time.timeSinceLevelLoad >= 4.0f && Time.timeSinceLevelLoad <= 12.0f) {
			if (laugh.isPlaying) {
				goto A;
			} else if (!laugh.isPlaying && time1 < 7.0f)
				laugh.Play ();
		}
		A: {}
		if (time1 >= 5.0f && time1 <= 6.5f) {
			float phi = Time.timeSinceLevelLoad / duration * 2 * Mathf.PI;
			float amplitude = Mathf.Cos (phi);
			if (Mathf.Abs(amplitude) >= (0.5f)) {
				lt.intensity = 5.5f;
				lt1.intensity = 5.5f;
			} else {
				lt.intensity = 0f;
				lt1.intensity = 0f;
			}
		}
		if (time1 < 12.0f && time1 > 7f) {
			lampLight.SetActive(false);
			lampLightSpot.SetActive(false);
		}
			
		if (time1 >= 12.0f && !flicker) {
			lampLight.SetActive(true);
			lampLightSpot.SetActive(true);
			FlyingDemonModel.SetActive(true);
			lt.intensity = 6f;
			lt1.intensity = 6f;
		}

		if (teleport && !hit) {
			flicker = true;
			float phi = Time.timeSinceLevelLoad / duration * Mathf.PI;
			float amplitude = Mathf.Sin (phi*flickeringFrequency);

			if (Mathf.Abs(amplitude) >= (0.5f)) {
				lt.intensity = 7f;
				lt1.intensity = 7f;
			} else {
				lt.intensity = 0f;
				lt1.intensity = 0f;
			}
		
			counter += Time.fixedDeltaTime;
			if (counter >= 1.5f) {
				teleport = false;
			} else
				teleport = true;
		}
		if (hit) {
			flicker = true;
			float phi = Time.timeSinceLevelLoad / duration * Mathf.PI;
			float amplitude = Mathf.Sin (phi*flickeringFrequency);

			if (Mathf.Abs(amplitude) >= (0.5f)) {
				lt.intensity = 7f;
				lt1.intensity = 7f;
			} else {
				lt.intensity = 0f;
				lt1.intensity = 0f;
			}

			counter += Time.fixedDeltaTime;
			if (counter >= 1.5f) {
				hit = false;
			} else
				hit = true;
		}
		else if (!teleport && !hit && flicker) {
			lt.intensity = 5f;
			lt1.intensity = 5f;
			counter = 0;
			hit = false;
		}
	}

	void Flicker() {
		teleport = true;
	}

	void Hit () {
		hit = true;
	}
}