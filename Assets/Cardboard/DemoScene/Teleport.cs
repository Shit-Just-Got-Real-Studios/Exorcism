﻿// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour {

  [SerializeField]
  private float distanceFromPlayerWhileAttacking;

  [SerializeField]
  private float demonSpawningSpeed;

  [SerializeField]
  private GameObject player;

  [SerializeField]
  private GameObject demon;

  [SerializeField]
  private GameObject demonModel;

  [SerializeField]
  private GameObject flyingDemonModel;

  [SerializeField]
  private GameObject bloodSplat;

  private Vector3 startingPosition;      
  public Transform[] spawnPoints;  
  public int score = 0;
  public int levelIndex = 1;
  public bool teleport = false;
  private int numOfTries = 5;
  public bool attacking = false;
  private int counter = 1;
  //private int animCounter = 0;

  void Start() {
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		transform.position = (spawnPoints[spawnPointIndex].position);
        startingPosition = transform.localPosition;
        SetGazedAt(false);
		demonModel.SetActive (false);
		InvokeRepeating("TeleportRandomly", 0, demonSpawningSpeed);
  }


  void FixedTimeBeforeTeleport(int levelIndex) {
		if (Time.timeSinceLevelLoad - (int)Time.timeSinceLevelLoad <= 0.04f) {
			if ((int)Time.timeSinceLevelLoad % (int)(15.0f / (levelIndex * 0.5f)) == 0) {
				attacking = true;
				GameObject pos = GameObject.Find ("DemonSpawn");
				transform.position = new Vector3 (pos.transform.position.x, 0, pos.transform.position.z);
				AttackPlayer ();
				Handheld.Vibrate();
				BloodSplat ();
				player.SendMessage ("ApplyDamage", 5.0f, SendMessageOptions.DontRequireReceiver);
			} 

			if (!GetComponent<Animation> ().isPlaying) {
				attacking = false;
				TeleportRandomly ();
			}
		}
  }
  void Update() {
		if (score >= 12) {
			if (Cardboard.SDK.VRModeEnabled)
				SceneManager.LoadScene (7);
			else
				SceneManager.LoadScene (8);
			demon.SetActive (false);
			gameObject.SetActive (false);

			/*
			if (GetComponent<Animation> ().isPlaying)
				goto A;
			else {
				if (animCounter == 0) {
					this.GetComponent<Animation> ().Play("back_fall");
					animCounter++;
				}
					
			}
			A: {}
			*/
		}
		if(Cardboard.SDK.Triggered) {
			numOfTries -= 1;
			if (numOfTries == 0) {

			}
			if (score == 1) {
				levelIndex++;
				numOfTries = 5;
			} else if (score == 3) {
				levelIndex++;
				numOfTries = 5;
			} else if (score == 6) {
				levelIndex++;
				numOfTries = 5;

			} else if (score == 10) {
				levelIndex++;
				numOfTries = 5;
			} else if (score == 15) {
				levelIndex++;
				numOfTries = 5;
			} 
		}

		FixedTimeBeforeTeleport (levelIndex);
		if ((int)Time.timeSinceLevelLoad % (int)(10 / (levelIndex * 0.5f)) != 0) {
			if (Vector3.Distance (player.transform.position, transform.position) <= 8.0f && !attacking) {
				TeleportRandomly ();
			}
		}
		if (!attacking) {
			Normal ();
		}
  }
  void Normal () {
		Vector3 targetPosition = new Vector3 (player.transform.position.x,this.transform.position.y,player.transform.position.z);
		this.transform.LookAt (targetPosition);
		Vector3 oldPos = new Vector3 (transform.position.x, 0f, transform.position.z);
		transform.position = oldPos; 
		transform.Translate (Vector3.forward * Time.deltaTime);
		this.GetComponent<Animation> ().CrossFade ("walk");
		teleport = false;
  }
  void LateUpdate() {
    Cardboard.SDK.UpdateState();
    if (Cardboard.SDK.BackButtonPressed) {
      Application.Quit();
    }
  }

  void AttackPlayer () {
		Vector3 targetPosition = new Vector3 (player.transform.position.x,this.transform.position.y,player.transform.position.z);
		this.transform.LookAt (targetPosition);
		Vector3 oldPos = new Vector3 (transform.position.x, 0f, transform.position.z);
		transform.position = oldPos;
		this.GetComponent<Animation> ().Stop ("walk");
		this.GetComponent<Animation> ().CrossFade ("attack");
  }

  public void SetGazedAt(bool gazedAt) {
    GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
  }

  public void Reset() {
    transform.localPosition = startingPosition;
  }

  public void ToggleVRMode() {
    Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
  }

  public void TeleportRandomly() {
	GameObject flicker = GameObject.Find ("GameIntroScene");
	flicker.SendMessage ("Flicker", SendMessageOptions.DontRequireReceiver);
	teleport = true;
	int spawnPointIndex = Random.Range (0, spawnPoints.Length);
	transform.localPosition = spawnPoints [spawnPointIndex].position;
	counter++;
  }

  public void DemonHit() {
	if (!attacking) {
		score += 1;
		GameObject flicker = GameObject.Find ("GameIntroScene");
		flicker.SendMessage ("Hit", SendMessageOptions.DontRequireReceiver);
		if (!attacking)
			TeleportRandomly ();
		}
  	}

	public void BloodSplat() {
		bloodSplat.SendMessage ("StartFunction", SendMessageOptions.DontRequireReceiver);
	}
}
