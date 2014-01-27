using UnityEngine;
using System.Collections;

public class ClickThrough : MonoBehaviour {

	float  timer = 0;
	bool timerStarted = false;
	public int scenesPassed = 0;

	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0) && scenesPassed == 0) {
			timerStarted = true;
		}

		if (timerStarted) {
			timer += Time.deltaTime;
		}
	
		if (timer > 0f) {
			GameObject.Find ("fadeOut").GetComponent<fadeOutControllerCS>().startTimer();
		}
		
		if (timer > 2f) {
			timer = 0;
			timerStarted = false;
			scenesPassed = 1;
			Application.LoadLevel ("touchTime");		
		}

	}
}
