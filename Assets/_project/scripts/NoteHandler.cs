using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

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

	public GameObject notePrefab;
	public float noteSpeed; // hyperspeed
	//public Notes[] loadedNotes;
	public float onMeasure;

	public void SpawnNotes() {
		// LIST VERSION //
		// create fake note data
		List<Notes> sampleNotes = new List<Notes>();
		sampleNotes.Add(new Notes(0, 0, 0, 0, 1));
		sampleNotes.Add(new Notes(1, 1, 1, 0, 7));
		sampleNotes.Add(new Notes(3, 2, 0, 0, 3));
		sampleNotes.Add(new Notes(8, 3, 2, 0, 5));
		sampleNotes.Add(new Notes(9, 0, 0, 1, 0));
		sampleNotes.Add(new Notes(10, 1, 1, 1, 4));
		sampleNotes.Add(new Notes(11, 2, 0, 1, 2));
		sampleNotes.Add(new Notes(12, 3, 2, 1, 6));
		sampleNotes.Add(new Notes(13, 1, 0, 0, 8));
		sampleNotes.Add(new Notes(13, 2, 0, 1, 8));

		// load fake note data
		List<Notes> loadedNotes = sampleNotes;

		// go through note list
		foreach (Notes note in loadedNotes) {
			// instantiate a new note at offset
			GameObject g = Instantiate(notePrefab, new Vector3(
				-1.5f + note.lineIndex, // x
				0.5f + note.lineLayer,  // y
				note.time * noteSpeed   // z
			), Quaternion.identity);

			g.GetComponent<Notebox>().noteType = note.type; // set L/R color
			g.GetComponent<Notebox>().noteDirection = (Notebox.NoteDir)note.cutDirection; // set cut direction
		}
	}

	public void MoveForward() {

	}
	public void MoveBack() {

	}
}
