using UnityEngine;
using System.Collections;

public class Backgournd : MonoBehaviour {
	
	public Texture2D imgtexture = null;
	public Rect Imagedata;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){
		if(imgtexture != null){
			/*get image data(position,contentSize)*/
			Rect imageRect = new Rect(Imagedata.x,Imagedata.y,Screen.width,Screen.height);
			/*draw texture*/
			GUI.color = new Color(1.0f,1.0f,1.0f,1.0f);
			GUI.DrawTexture(imageRect,imgtexture);	
		}	
	}
	
}
