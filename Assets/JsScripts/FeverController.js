#pragma strict

private var bar : ProgressBar; 
private var feverBtn : MenuImageButton;
private var logic:GameScoreLogic;
private var fevering : boolean;

function Start () {
	/*get progress bar from child*/
	bar = gameObject.GetComponentInChildren(typeof(ProgressBar));
	/*get button from child*/
	feverBtn = gameObject.GetComponentInChildren(typeof(MenuImageButton));
	/*get score logic*/
	var scoreObj:GameObject = GameObject.FindGameObjectWithTag("GameScore") as GameObject;
	logic = scoreObj.GetComponent(typeof(GameScoreLogic)) as GameScoreLogic;
	
	fevering = false;
}

function Update () {
	/*if bar State is no longer increase*/
	if(bar.getState() == BarState.stoping && 
	   bar.getModel() == RunningModel.increase){
	   feverBtn.enable = true;
	   /*setting fevering stating is true if state is false*/
	   if(!fevering) fevering = true;
	   
	/*if bar State no longer decrease*/
	}else if(bar.getState() == BarState.stoping &&
	         bar.getModel() == RunningModel.decrease &&
	         fevering){
	    feverBtn.enable = false;
	    fevering = false;
	    logic.Multple = logic.InitScore;
	    bar.model = RunningModel.increase;
	    bar.setState(BarState.running);
	    
	}else if(bar.getState() == BarState.running &&
	         bar.getModel() == RunningModel.decrease &&
	         fevering){
		/*logic multple upper*/
		if(logic.Multple < logic.MaxMultple && bar.value > bar.max) 
			logic.Multple = logic.Multple + 10;
		
	}
}