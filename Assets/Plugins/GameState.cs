using UnityEngine;
using System.Collections;

public enum STATE{
	g_begining,
	g_playing,
	g_pause,
	g_end
};

public sealed class GameState : MonoBehaviour {
	
	private STATE _state;

	void Awake() {
		_state = STATE.g_begining;
		/*stop update*/
		this.enabled = false;
	}
	
	public STATE State{ 
		get{return _state;}
		set{_state = value;}
	}
}
