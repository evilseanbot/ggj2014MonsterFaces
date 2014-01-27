using UnityEngine;
using System.Collections;

public class fadeOutControllerCS : MonoBehaviour {

	float  timer = 0;
	bool timerStarted = false;

	void OnGUI()
	{
		if (timerStarted) {
			timer += Time.deltaTime;
			float guiAlpha = ((timer/4f));
			Color myColor = guiTexture.color;
			myColor.a = guiAlpha;
			guiTexture.color = myColor;
		}
		//GUI.color = new Color(0,0,0,guiAlpha);
		//GUI.DrawTexture(Rect(0,0,Screen.width,Screen.), flatTexture, ScaleMode.ScaleToFit, true, 10.0f);    
		//Debug.Log(timer);
	}
	
	public void startTimer() {
		timerStarted = true;
	}

}
