#pragma strict

var timer: float = 0;
var timerStarted: boolean = true;

function Start () {

}

function Update () {
 }

function OnGUI()
{
    if (timerStarted) {
	    timer += Time.deltaTime;
	    var guiAlpha:float = ((timer/3f));
	    guiTexture.color.a = guiAlpha;
	}
    //GUI.color = new Color(0,0,0,guiAlpha);
    //GUI.DrawTexture(Rect(0,0,Screen.width,Screen.), flatTexture, ScaleMode.ScaleToFit, true, 10.0f);    
    //Debug.Log(timer);
}

function startTimer() {
    timerStarted = true;
}