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
	public Notes[] loadedNotes;

	//// spawn notes for testing
	//void Start() {
	//	SpawnNotes();
	//}

	public void SpawnNotes() {
		///*	
		// create fake note data
		Notes[] sampleNotes = new Notes[10];
		sampleNotes[0] = new Notes(0, 0, 0, 0, 1);
		sampleNotes[1] = new Notes(1, 1, 1, 0, 7);
		sampleNotes[2] = new Notes(3, 2, 0, 0, 3);
		sampleNotes[3] = new Notes(8, 3, 2, 0, 5);
		sampleNotes[4] = new Notes(9, 0, 0, 1, 0);
		sampleNotes[5] = new Notes(10, 1, 1, 1, 4);
		sampleNotes[6] = new Notes(11, 2, 0, 1, 2);
		sampleNotes[7] = new Notes(12, 3, 2, 1, 6);
		sampleNotes[8] = new Notes(13, 1, 0, 0, 8);
		sampleNotes[9] = new Notes(13, 2, 0, 1, 8);	
		
		// load fake note data
		Notes[] loadedNotes = sampleNotes;
		//*/


		// go through note array
		foreach (Notes note in loadedNotes) {
			// instantiate a new note at offset
			GameObject g = Instantiate(notePrefab, new Vector3(
				-1.5f + note.lineIndex,	// x
				0.5f + note.lineLayer,  // y
				note.time * noteSpeed	// z
			), Quaternion.identity);

			g.GetComponent<Notebox>().noteType = note.type; // set L/R color
			g.GetComponent<Notebox>().noteDirection = (Notebox.NoteDir)note.cutDirection; // set cut direction
		}

	}

}
