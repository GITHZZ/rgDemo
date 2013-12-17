using UnityEngine;
using System.Collections;

enum ButtonState{
	unselected = 0,
	selected = 1
};

public class MenuImageButton : MonoBehaviour {
	/*set button position*/
	public Vector2 position;
	/*set button scale*/
	public float scale = 1.0f;
	/*button enable can touch*/
	public bool enable = true;
	/*button not press texture and pressed texture*/
	public Texture2D imageunselected = null;
	public Texture2D imagetselected = null;
	/*load texture Rect data from imagetext-ure1 and imagetexture2*/   
	private Rect textureRect;
	/*button state*/
	private ButtonState m_state;
	/*used to send message to method function*/
	public string selector_func_name;

	/*Use this for initialization*/
	void Start () {
		m_state = ButtonState.unselected;
		if(scale == 0) scale = (float)(Screen.width/4)/imageunselected.width;
		if(position==Vector2.zero) {
			position.x=(Screen.width-imageunselected.width*scale)/2.0f;
			position.y=(Screen.height-imageunselected.height*scale)/1.3f;
		}
		if(position.x == -1){
			position.x = Screen.width-((imageunselected.width*scale));
		}
		if(imageunselected != null){
			textureRect = new Rect(position.x,
								   position.y,
								   imageunselected.width*scale,
								   imageunselected.height*scale);
		}
	}
	
	/*Update is called once per frame*/
	void Update () {
		//get Mouse button left 
		if(Input.GetMouseButtonDown(0)){
			Vector2 realPos = new Vector2(Input.mousePosition.x,Screen.height-Input.mousePosition.y);
			if(textureRect.Contains(realPos)){
				m_state = ButtonState.selected;
			}
		}else if(Input.GetMouseButtonUp(0)){
			Vector2 realPos = new Vector2(Input.mousePosition.x,Screen.height-Input.mousePosition.y);
			if(textureRect.Contains(realPos)){
				m_state = ButtonState.unselected;
				if(enable) button_func();
			}
		}
	}
	
	/*draw 2D button texture acrossing button state*/
	void OnGUI(){
		/*update texture rect*/
		textureRect.x = position.x;
		textureRect.y = position.y;

		if(m_state == ButtonState.unselected){
			if(imageunselected != null){
				GUI.DrawTexture(textureRect,imageunselected);
			}
		}else if(m_state == ButtonState.selected){
			if(imagetselected != null){
				GUI.DrawTexture(textureRect,imagetselected);
			}
		}
	}
	
	/*selector when button press down*/
	void button_func(){
		/*game func when button pressed down*/
		if(selector_func_name != ""){
			this.SendMessage(selector_func_name);
		}else{
			Debug.LogError("selector method is null!");
		}
	}
}
