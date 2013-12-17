using UnityEngine;
using System.Collections;

public class GameTitle : MonoBehaviour {

	public Texture2D titleImage;
	public Vector2 position;
	public float scale;

	private Rect imageRect;

	void Start () {
		if(scale == 0) scale = (float)(Screen.width/1.5)/titleImage.width;
		if(position==Vector2.zero) {
			position.x=(Screen.width-titleImage.width*scale)/2;
			position.y=(Screen.height-titleImage.height*scale)/5;
		}
		if(titleImage != null){
			imageRect = new Rect(position.x,
			                     position.y,
			                     titleImage.width * scale,
			                     titleImage.height * scale);
		}
	}

	void OnGUI () {
		if (titleImage == null) return;
		GUI.DrawTexture(imageRect,titleImage);
	}
}
