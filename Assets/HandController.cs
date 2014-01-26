using UnityEngine;
using System.Collections;
using Leap;

public class HandController : MonoBehaviour {
	LeapManager myLeapManagerInstance;

	// Use this for initialization
	void Start () {
		myLeapManagerInstance = (GameObject.Find("LeapManager") as GameObject).GetComponent(typeof(LeapManager)) as LeapManager;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = myLeapManagerInstance.frontmostHand ().PalmPosition.ToUnityTranslated();

		if (transform.position.z > -8.4f) {
			GameObject.Find("SadMonster").GetComponent<MonsterControllerCS>().touch();
		} else if (transform.position.z < -8.9f) {
			GameObject.Find("SadMonster").GetComponent<MonsterControllerCS>().touchOff();
		
		}
	}
}
