#pragma strict
var zhangai:GameObject;
var allChildren;			//用来获取子物体列表	
var speed:float=0.1;		//移动速度
var MaxTime:float;
var DTime:float = MaxTime;
var _gState:GameState;

function Start () {
	/*get parent object GameState*/
	var parentObject = GameObject.FindGameObjectWithTag("GameState");
	_gState = parentObject.GetComponent(typeof(GameState)) as GameState;
		
	CreatZhngai();
}

function Update () {
	if(_gState.State == STATE.g_playing){
		DTime = DTime-Time.deltaTime;
		if(DTime<=0){
			DTime = MaxTime;
			CreatZhngai();
		}
		for (var child:Transform in gameObject.GetComponentsInChildren(Transform)){
			child.transform.Translate(speed,0,0);
			if (child.position.x>50){
				Destroy(child.gameObject);
			}
		}
		transform.RotateAround (Vector3.zero, Vector3.right, Input.acceleration.x);
		transform.transform.position = Vector3.zero;
	}
}

function CreatZhngai() {
	var instance:GameObject=Instantiate(zhangai,zhangai.transform.position,zhangai.transform.rotation);
	var jd = Random.Range(0,360);
	var hd = jd*Mathf.PI/180;
	var Rz = Mathf.Cos(hd);
	var Ry = Mathf.Sin(hd);
	instance.transform.parent = this.transform;
	instance.transform.Translate(0,Ry,Rz);
	instance.transform.Rotate(Vector3(270-jd,0,0));
}