using UnityEngine;
using System.Collections;

public class MonsterControllerCS : MonoBehaviour {
	
	public Texture2D controlTexture;
	public Material happyFace;
	float comfortLevel = 100f;
	float happyLevel = 0f;
	float timeOutTimer = 0f;
	bool timingOut = false;
	bool wantTouch = false;
	bool touching = false;
	bool happy = false;
	bool touched = false;

	public AudioClip mattie1;
	public AudioClip mattie2;
	public AudioClip mattie3;


	void Start () {
		float rando = Random.value;
		if (rando > 0.5f) {
			wantTouch = true;
		} else {
			wantTouch = false;
		}

		// For debug purposes:
		//wantTouch = true;
	}
	
	void FixedUpdate () {
		if (touching && !wantTouch) {
			comfortLevel -= (Time.deltaTime*33);
		}
		if (touching && wantTouch) {
			happyLevel += Time.deltaTime;
		}

		if (happyLevel > 2f) {
			if (!happy) {
				happy = true;
				GameObject.Find("MonsterFace").GetComponent<MeshRenderer>().sharedMaterial = happyFace;
				GameObject.Find ("Directional light").GetComponent<Light>().intensity = 1.0f;

				setRandomMattieClip();
				GameObject.Find ("Main Camera").GetComponent<AudioSource>().Play ();
			}
		}

		if (timingOut) {
			timeOutTimer += Time.deltaTime;
		}

		if (timeOutTimer > 1f) {
			GameObject.Find ("fadeOut").GetComponent<fadeOutControllerCS>().startTimer();
		}

		if (timeOutTimer > 3f) {

			if (GameObject.Find("Scene Counter").GetComponent<ClickThrough>().scenesPassed > 3) {
				Application.LoadLevel ("end");		
		}
			 else {
			GameObject.Find ("Scene Counter").GetComponent<ClickThrough>().scenesPassed++;
			    Application.LoadLevel ("touchTime");		}
	        }
	}

	public void touch() {
		if (wantTouch && !touched) {
			touching = true;
			gameObject.GetComponent<Animator>().Play("HeadLift");	
		} else if (!wantTouch) {
			touching = true;
		    gameObject.GetComponent<Animator>().Play("HeadShake");	
		}
		touched = true;

	}

	public void touchOff() {
		if (touching) {
			timingOut = true;
		}

		touching = false;
		if (!happy) {
		    gameObject.GetComponent<Animator>().Play("New State");	
		}

	}

	void OnGUI() {

		float height = 50f;
		float width = 3f * comfortLevel;

		GUI.Box (new Rect (0,Screen.height - 50,100,50), "Comfort-Zone");
		GUI.DrawTexture(new Rect(0,Screen.height - 100, width, height), controlTexture, ScaleMode.ScaleToFit, true, width/height);
	}

	void setRandomMattieClip() {
		float rando = Random.value * 3f;
		AudioClip clip = GameObject.Find ("Main Camera").GetComponent<AudioSource>().clip;

		if (rando < 1) {
			GameObject.Find ("Main Camera").GetComponent<AudioSource>().clip = mattie1;
		} else if (rando < 2) {
			GameObject.Find ("Main Camera").GetComponent<AudioSource>().clip = mattie2;
		} else {
			GameObject.Find ("Main Camera").GetComponent<AudioSource>().clip = mattie3;
		}
	}
}
