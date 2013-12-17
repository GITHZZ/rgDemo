using UnityEngine;
using System.Collections;

enum ActionState{
	Start,
	Stop
};

[RequireComponent (typeof(MenuImageButton))]

public class MenuImageAction : MonoBehaviour {

	public Vector2 origination;
	public Vector2 target;
	public float speed = 1.0f;

	private MenuImageButton _imageButton;
	private ActionState _state;

	private Vector2 _subVector;

	void Awake () {
		_imageButton = gameObject.GetComponent(typeof(MenuImageButton)) as MenuImageButton;
		if(_imageButton.position != origination) origination = _imageButton.position;
	}

	void Start () {
		_state = ActionState.Stop;
	}

	public void Run () {
		_subVector = target - origination;
		_state = ActionState.Start;
	}
	
	public void Stop () {
		_state = ActionState.Stop;
	}

	void Update () {
		if(_state == ActionState.Start){
			Vector2 normalize = _subVector / Mathf.Sqrt(_subVector.x * _subVector.x + _subVector.y * _subVector.y); 
			_imageButton.position += normalize * speed;

			if(_imageButton.position == target){
				origination = target;
				this.Stop();
			}
		}
	}
}
