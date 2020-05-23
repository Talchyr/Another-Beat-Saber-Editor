using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebox : MonoBehaviour
{
	public NoteDir noteDirection;
	public int noteType;
	public GameObject arrow;
	public GameObject dot;
	public GameObject box;

	public enum NoteDir {
		Up,
		Down,
		Left,
		Right,
		UpLeft,
		UpRight,
		DownLeft,
		DownRight,
		Any
	}

	private void Start() {
		SetColor();
		SetRotation();
	}

	void SetColor() {
		switch (noteType) {
			case 0:
				box.GetComponent<Renderer>().material.color = Color.red; // (replace with global color later)
				break;
			case 1:
				box.GetComponent<Renderer>().material.color = Color.blue; // (replace with global color later)
				break;
			default:
				Debug.Log("Error in setting note type int.");
				break;
		}
		
	}

	void SetRotation() {
		if (noteDirection == NoteDir.Any) {
			dot.SetActive(true);
			arrow.SetActive(false);
			gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
		} 
		else {
			dot.SetActive(false);
			arrow.SetActive(true);
			switch (noteDirection) {
				case NoteDir.Down:
					gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
					break;
				case NoteDir.DownRight:
					gameObject.transform.eulerAngles = new Vector3(0, 0, 45);
					break;
				case NoteDir.Right:
					gameObject.transform.eulerAngles = new Vector3(0, 0, 90);
					break;
				case NoteDir.UpRight:
					gameObject.transform.eulerAngles = new Vector3(0, 0, 135);
					break;
				case NoteDir.Up:
					gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
					break;
				case NoteDir.UpLeft:
					gameObject.transform.eulerAngles = new Vector3(0, 0, 225);
					break;
				case NoteDir.Left:
					gameObject.transform.eulerAngles = new Vector3(0, 0, 270);
					break;
				case NoteDir.DownLeft:
					gameObject.transform.eulerAngles = new Vector3(0, 0, 315);
					break;
			}
		}
	}
}
