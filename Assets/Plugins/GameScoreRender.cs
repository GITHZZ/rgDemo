using UnityEngine;
using System.Collections;

[RequireComponent (typeof(GameScoreLogic))]

public class GameScoreRender : MonoBehaviour {

	public Vector2 position;
	private GameScoreLogic logic;

	void Start () {
		logic = this.GetComponent(typeof(GameScoreLogic)) as GameScoreLogic;
	}
	
	void OnGUI() {
		int score = logic.Score;
		int multple = logic.Multple;	
		int maxScore = logic.MaxScore;
		/*render score label*/
		GUI.color = new Color(0.0f,0.0f,0.0f);
		GUI.Label(new Rect(position.x,position.y,400,60),
			          "Score:" + score.ToString() + " | " + maxScore.ToString() +
		  	          "   " + "X" + multple);
	}
}
