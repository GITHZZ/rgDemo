#pragma strict

private var gState:GameState;

var cube:GameObject;  		//要创建的预设物体
var allChildren;			//用来获取子物体列表	
var speed:float=0.1;		//移动速度
var tongdaoCount:int=5;		//创建的数量
var deltaY:float=10;				//相邻物体间的position.y的距离
var _player:GameObject;

function Start () {
	var parentObj = GameObject.FindGameObjectWithTag("GameState");
	gState = parentObj.GetComponent(typeof(GameState)) as GameState;
	
	//初始化 创建出需要的物体、将创建的物体加到空objiect里面、设置物体的位置
	for (var i=0;i<tongdaoCount;i++){
		var instance:GameObject=Instantiate(cube,cube.transform.position,cube.transform.rotation);
		instance.transform.parent = this.transform;
		instance.transform.Translate(0,i*deltaY,0);
	}
	//获取子物体列表
	allChildren = gameObject.GetComponentsInChildren(Transform);
	//get Player
	_player = GameObject.FindGameObjectWithTag("GamePlayer");
}

function Update () {
	if(gState.State == STATE.g_playing){
		//通过allChildren遍历子物体
		for (var child : Transform in allChildren){
			//判断位置，超出位置的范围到position.y=0的位置上
			if(child.transform.position.x > tongdaoCount*deltaY){
				child.transform.position.x=0;
			}
			//根据速度对子物体进行平移
			child.transform.Translate(0,speed,0);
			//保持空object的位置不变
			this.transform.position.y=1;
		}
		
		if(Application.platform == RuntimePlatform.Android || 
		   Application.platform == RuntimePlatform.IPhonePlayer){
			//根据重力感应旋转
			transform.Rotate(Vector3(Input.acceleration.x,0,0));
		}
		
		/*in pc or osx*/
		if(Application.platform == RuntimePlatform.OSXPlayer ||
		   Application.platform == RuntimePlatform.WindowsPlayer ||
		   Application.platform == RuntimePlatform.WindowsEditor||
		   Application.platform == RuntimePlatform.OSXEditor){
		   
			if(Input.GetKey(KeyCode.LeftArrow)){
				_player.animation.Play("Left");
				transform.Rotate(Vector3(-2,0,0));
			}
			if(Input.GetKey(KeyCode.RightArrow)){
			    _player.animation.Play("Right");
				transform.Rotate(Vector3(2,0,0));
			}
		}
		
		//保持空object的位置不变
		transform.transform.position = Vector3.zero;
	}
}