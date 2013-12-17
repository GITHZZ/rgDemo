#pragma strict

var bloodBar:ProgressBar;
var feverBar:ProgressBar;

function Start () {
	var barObj = GameObject.FindGameObjectWithTag("Blood");
	bloodBar = barObj.GetComponent(typeof(ProgressBar)) as ProgressBar;

	var feverObj = GameObject.FindGameObjectWithTag("FeverBar");
	feverBar = feverObj.GetComponent(typeof(ProgressBar)) as ProgressBar;
}

function Update () {

}

function OnTriggerEnter(obj:Collider){
	if(bloodBar.value >= 0) bloodBar.value -= 10;
	if(feverBar.value >= 0) feverBar.value -= 10;
}