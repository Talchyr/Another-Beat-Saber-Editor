using System;
using System.Collections;
using System.Collections.Generic;
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
}
