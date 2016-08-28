using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InitialCondition : MonoBehaviour {
	
	[SerializeField]
	private Image thisImage;
	void Update () {
		if (Time.timeSinceLevelLoad < 2.0f) {
			Color alpha = thisImage.color;
			alpha.a = 0.0f;
			thisImage.color = alpha;
		}
	}
}
