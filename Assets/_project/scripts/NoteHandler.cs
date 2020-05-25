using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class NoteHandler : MonoBehaviour
{

	public GameObject notePrefab;
	public float noteSpeed; // hyperspeed
	public List<Notes> editorNotes;
	public float onMeasure;
	GameObject noteHolder;
	public Vector2 noteDisplayRange;
	public bool play;

	public class Notes {
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

	private void Start() {
		noteHolder = new GameObject("NoteHolder"); // create note parent
	}

	public void LoadNotes() {
		// LIST VERSION //

		/*
		/// create fake note data
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

		/// load fake note data
		editorNotes = sampleNotes;
		*/

		// load note data
		editorNotes = gameObject.GetComponent<DataHandler>().loadedNotes;

		// delete notes already in the scene
		if (noteHolder != null) {
			Destroy(noteHolder);
		}
		noteHolder = new GameObject("NoteHolder"); // replace deleted note holder

		// go through note list
		foreach (Notes note in editorNotes) {
			GameObject n = Instantiate(notePrefab, noteHolder.transform); // instantiate a new note as child

			// offset the note
			n.transform.position = new Vector3(
				-1.5f + note.lineIndex, // x
				0.5f + note.lineLayer,  // y
				note.time * noteSpeed   // z
			);

			n.GetComponent<Notebox>().noteType = note.type; // set L/R color
			n.GetComponent<Notebox>().noteDirection = (Notebox.NoteDir)note.cutDirection; // set cut direction
		}
	}

	void Update() {
		// note display range
		foreach (Transform n in noteHolder.GetComponentInChildren<Transform>()) {
			//Debug.Log(n.gameObject);
			if (n.position.z > noteDisplayRange.x && n.position.z < noteDisplayRange.y) {
				n.gameObject.SetActive(true);
			}
			else {
				n.gameObject.SetActive(false);
			}
		}

		// * map automatically scrolls
		if (play) {
			noteHolder.transform.position = new Vector3(0, 0, noteHolder.transform.position.z - (noteSpeed * 2 * Time.deltaTime));
		}
	}

	public void MoveForward() {

	}

	public void MoveBack() {

	}
}
