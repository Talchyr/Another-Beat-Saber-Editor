using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUIHandler : MonoBehaviour
{
	public bool loadMap;
	public float cursorOnMeasure;

	private void Update() {
		if (loadMap) {
			gameObject.GetComponent<NoteHandler>().SpawnNotes();
			loadMap = false;
		}
	}
}
