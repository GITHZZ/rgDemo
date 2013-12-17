using UnityEngine;
using System.Collections;

public class ContinueFunc : MonoBehaviour {

	private GameState gState;

	private MenuImageAction _continueAction;
	private MenuImageAction _homeAction;
	private MenuImageAction _restartAction;

	void Start () {
		/*get parent object GameState*/
		GameObject parentObject = GameObject.FindGameObjectWithTag("GameState");
		gState = parentObject.GetComponent(typeof(GameState)) as GameState;

		/*get buttons*/
		GameObject continueObj = GameObject.FindGameObjectWithTag("Continue");
		_continueAction = continueObj.GetComponent(typeof(MenuImageAction)) as MenuImageAction;
		
		GameObject homeObj = GameObject.FindGameObjectWithTag("Home");
		_homeAction = homeObj.GetComponent(typeof(MenuImageAction)) as MenuImageAction;
		
		GameObject restartObj = GameObject.FindGameObjectWithTag("Restart");
		_restartAction = restartObj.GetComponent(typeof(MenuImageAction)) as MenuImageAction;

	}

	void Update () {
	
	}

	void selector_func(){
		/*go back state is playing*/
//		if(gState.State == STATE.g_pause) {
//			gState.State = STATE.g_playing;
//
//			/*contine Action*/
//			_continueAction.target = new Vector2(410,10);
//			_continueAction.Run();
//			
//			/*home Action*/
//			_homeAction.target = new Vector2(410,10);
//			_homeAction.Run();
//			
//			/*restart Action*/
//			_restartAction.target = new Vector2(410,10);
//			_restartAction.Run();
//		}
	}
}
