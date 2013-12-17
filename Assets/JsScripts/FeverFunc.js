#pragma strict

private var logic:GameScoreLogic;
private var feverBtn:MenuImageButton;
private var proBar:ProgressBar;

function Awake () {
	var scoreObj:GameObject = GameObject.FindGameObjectWithTag("GameScore") as GameObject;
	logic = scoreObj.GetComponent(typeof(GameScoreLogic)) as GameScoreLogic;

	var feverObj:GameObject = GameObject.FindGameObjectWithTag("FeverButton") as GameObject;
	feverBtn = feverObj.GetComponent(typeof(MenuImageButton)) as MenuImageButton;

	var proBarObj:GameObject = GameObject.FindGameObjectWithTag("FeverBar") as GameObject;
	proBar = proBarObj.GetComponent(typeof(ProgressBar)) as ProgressBar;
}

function selector_func () {
	/*change Score _multiple value*/
	logic.Multple = logic.Multple + 10;
	/*change fever Button State*/
	feverBtn.enable = false;
	/*change progress bar running model*/
	proBar.model = RunningModel.decrease;
	proBar.setState(BarState.running);
}