using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUIHandler : MonoBehaviour
{
	public bool loadMap;
	//public float cursorOnMeasure;
	public bool measureFwd;
	public bool measureBack;

	private void Update() {
		if (loadMap) {
			gameObject.GetComponent<NoteHandler>().LoadNotes();
			loadMap = false;
		}

		if (measureBack) {

			measureBack = false;
		}
		if (measureFwd) {

			measureFwd = false;
		}
	}
}
