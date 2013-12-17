#pragma strict

enum BarState {
	running = 1,
	stoping = 2
};

enum RunningModel {
	increase = 1,
	decrease = 2,
};

var model:RunningModel = RunningModel.increase;
var autoUpdate:boolean = true;
var max:float = 10.0f;	//最大值
var value:float = 5.0f;	//当前值
var position:Vector2;
var width:float = 0.0f;
var height:float = 0.0f;

private var gState:GameState;
private var barState:BarState;

function Awake() {
	var parentObj = GameObject.FindGameObjectWithTag("GameState");
	gState = parentObj.GetComponent(typeof(GameState)) as GameState;
	
	barState = BarState.running;
}

function Start () {
	if(model == RunningModel.decrease) value = max;
}

function Update () {
	if(autoUpdate) {
		if(gState.State == STATE.g_playing && barState == BarState.running){
			if(model == RunningModel.increase) {
				value += 0.01;
				/*if value equal max change state*/
				if(value >= max) barState = BarState.stoping;
			}else if(model == RunningModel.decrease){
				value -= 0.01;
				/*if value lower than 0 change state*/
				if(value <= 0) {
					barState = BarState.stoping;
					value = 0;
				}
			}
		}
		
//		if(barState == BarState.stoping&&value < max){
//			
//		}
	}
}

function setValue (val:float){
	value = val;
}

function getState (){
	return barState;
}

function setState (s:BarState){
	barState = s;
}

function getModel(){
	return model;
}

function OnGUI () {
	GUI.HorizontalScrollbar (Rect(position.x,position.y,width,height), 0, value, 0, max);
}