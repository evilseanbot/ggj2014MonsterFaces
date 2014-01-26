using UnityEngine;
using System.Collections;

public class MonsterControllerCS : MonoBehaviour {

	public Texture2D controlTexture;
	float comfortLevel = 100f;
	bool wantTouch = false;
	bool touching = false;

	void Start () {
	
	}
	
	void FixedUpdate () {
		if (touching && !wantTouch) {
			comfortLevel -= 1f;
		}
	}

	public void touch() {
		//gameObject.GetComponent<Animator>().Play("HeadLift");	
		gameObject.GetComponent<Animator>().Play("HeadShake");	
		touching = true;
	}

	public void touchOff() {
		touching = false;
	}

	void OnGUI() {

		float height = 50f;
		float width = 3f * comfortLevel;

		GUI.Box (new Rect (0,Screen.height - 50,100,50), "Comfort-Zone");
		//GUI.Label (new Rect (0,Screen.height - 100,800,100), controlTexture);
		GUI.DrawTexture(new Rect(0,Screen.height - 100, width, height), controlTexture, ScaleMode.ScaleToFit, true, width/height);
	}
}
