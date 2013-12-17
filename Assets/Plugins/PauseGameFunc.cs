using UnityEngine;
using System.Collections;

public class PauseGameFunc : MonoBehaviour {

	private GameState gState;

	private MenuImageButton _menuImageBtn;

	private MenuImageAction _continueAction;
	private MenuImageButton _continueBtn;

	private MenuImageAction _homeAction;
	private MenuImageButton _homBtn;

	private MenuImageAction _restartAction;
	private MenuImageButton _restartBtn;

	void Start () {
		/*get parent object GameState*/
		GameObject parentObject = GameObject.FindGameObjectWithTag("GameState");
		gState = parentObject.GetComponent(typeof(GameState)) as GameState;

		/*get buttons*/
		GameObject pauseObj = GameObject.FindGameObjectWithTag("Pause");
		_menuImageBtn = pauseObj.GetComponent(typeof(MenuImageButton)) as MenuImageButton;

		GameObject continueObj = GameObject.FindGameObjectWithTag("Continue");
		_continueAction = continueObj.GetComponent(typeof(MenuImageAction)) as MenuImageAction;
		_continueBtn = pauseObj.GetComponent(typeof(MenuImageButton)) as MenuImageButton;

		GameObject homeObj = GameObject.FindGameObjectWithTag("Home");
		_homeAction = homeObj.GetComponent(typeof(MenuImageAction)) as MenuImageAction;

		GameObject restartObj = GameObject.FindGameObjectWithTag("Restart");
		_restartAction = restartObj.GetComponent(typeof(MenuImageAction)) as MenuImageAction;
	}

	void selector_func(){
		if(gState.State != STATE.g_pause){
			/*get game state is pauseing*/
			gState.State = STATE.g_pause;

			/*contine Action*/
			_continueAction.target = new Vector2(_menuImageBtn.position.x - 200,10);
			_continueAction.Run();
			
			/*home Action*/
			_homeAction.target = new Vector2(_menuImageBtn.position.x - 140,10);
			_homeAction.Run();

			/*restart Action*/
			_restartAction.target = new Vector2(_menuImageBtn.position.x - 80,10);
			_restartAction.Run();
		}
	}

	void OnGUI(){
		if(gState.State == STATE.g_pause){
			
		}
	}
}
