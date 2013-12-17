using UnityEngine;
using System.Collections;

public class StartLabel : MonoBehaviour {

	public string labelContent;
	public Color color;
	public Vector2 position;
	public float scale;

	private Rect labelRect;

	void Start () {
		if(scale == 0) scale = 1.0f;
		labelRect = new Rect(position.x,position.y,400,60);
	}

	void OnGUI () {
		GUI.color = color;
		GUI.Label(labelRect,labelContent);
	}
}
