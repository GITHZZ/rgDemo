using UnityEngine;
using System.Collections;

enum PlayerAnimType{
	left,
	right
};

public class Player : MonoBehaviour {


	private GameState _gState;

	void Start () {

	}

	void Update () {

	}

	void PlayAnimation(PlayerAnimType type){
		if(type == PlayerAnimType.left) this.animation.Play("Left");
		if(type == PlayerAnimType.right) this.animation.Play("Right");
	}

}
