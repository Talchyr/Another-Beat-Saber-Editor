using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

// handles 

public class NoteHandler : MonoBehaviour
{
	public class Notes
	{
		public	float	time;
		public	float	lineIndex;
		public	float	lineLayer;
		public	int		type; // color, im assuming
		public	int		cutDirection;

		public Notes (float t, float li, float ll, int c, int dir) {
			time = t;
			lineIndex = li;
			lineLayer = ll;
			type = c;
			cutDirection = dir;
		}
	}

	void Start() {
		// spawn notes for testing
		SpawnNotes();
	}

	public GameObject noteGameobj;
	public float noteSpeed;

	// spawn notes function
	void SpawnNotes() {
		// create fake note data
		Notes[] sampleNotes = new Notes[3];
		sampleNotes[0] = new Notes(0, 0, 0, 0, 0);
		sampleNotes[1] = new Notes(1, 0, 0, 0, 0);
		sampleNotes[2] = new Notes(3, 0, 0, 0, 0);
		//sampleNotes[3] = new Notes(8, 0, 0, 0, 0);

		// set notes to loaded notes
		Notes[] loadedNotes = sampleNotes;

		// spawn from note data
		foreach (Notes note in loadedNotes) {
			// instantiate a new thingy at note offset
			Instantiate(noteGameobj, new Vector3(0, 0, note.time * noteSpeed), Quaternion.identity);
		}
	}

}
