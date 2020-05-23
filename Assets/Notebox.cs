using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebox : MonoBehaviour
{
	public NoteDir noteDirection;
	public GameObject arrow;
	public GameObject dot;


	public enum NoteDir {
		Down,
		DownRight,
		Right,
		UpRight,
		Up,
		UpLeft,
		Left,
		DownLeft,
		Any
	}

	void Update() { // throwing this in update for now to see if it works
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
