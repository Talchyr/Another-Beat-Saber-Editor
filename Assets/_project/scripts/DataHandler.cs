using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataHandler : MonoBehaviour
{
	public string filePath;
	public string savePath; // * for testing
	public List<NoteHandler.Notes> loadedNotes;

	// * test save
	public void Start() {
		Load();
		//Save();
	}

	[System.Serializable]
	class MapData {
		public string _version;
		// _BPMChanges
		// _events
		public JsonNotes[] _notes;
	}

	[System.Serializable]
	class JsonNotes {
		public float _time;
		public float _lineIndex;
		public float _lineLayer;
		public int _type; // color, im assuming
		public int _cutDirection;
	}

	// load from file
	public void Load() {
		// convert json
		string json = File.ReadAllText(filePath);
		MapData map = JsonUtility.FromJson<MapData>(json);

		// add notes to array
		loadedNotes = new List<NoteHandler.Notes>();
		foreach (JsonNotes n in map._notes) {
			loadedNotes.Add(new NoteHandler.Notes(n._time, n._lineIndex, n._lineLayer, n._type, n._cutDirection));
		}
	}

	// save to file
	public void Save() {	

	}
}
