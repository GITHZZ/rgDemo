using UnityEngine;
using System.Collections;

public class GameScoreLogic : MonoBehaviour {

	private const int _maxMultiple = 120;
	private const int _initScore = 30;

	/*player score*/
	private int _score;
	private int _maxScore;
	private int _multiple;

	private GameState gState;

	private const string scoreKey = "ScoreKey";

	void Start () {
		/*get parent object GameState*/
		GameObject parentObject = GameObject.FindGameObjectWithTag("GameState");
		/*get gameState script*/
		gState = parentObject.GetComponent(typeof(GameState)) as GameState;
		
		this.initData();
	}
	
	void initData(){
		/*if State is begin init score*/
		if(gState.State == STATE.g_begining){
			_score = 0;
			_maxScore = PlayerPrefs.GetInt(scoreKey,0);
			_multiple = this.InitScore;
		}
		/*start game*/
		gState.State = STATE.g_playing;
	}
	
	void Update () {
		if(gState.State == STATE.g_playing){
			/*update game score*/
			_score += _multiple;
			/*if current score >= max score change _maxscore val*/
			if(_score > _maxScore) _maxScore = _score;
		}else if(gState.State == STATE.g_end){
			PlayerPrefs.SetInt(scoreKey,_maxScore);
			gState.State = STATE.g_begining;
		}
	}
	
	/*setting score multiple*/
	public int Multple {
		set{
			if(value <= 0){
				Debug.LogWarning("game Multple value must be > 0");
			}
			_multiple = value;
		}
		get{
			return _multiple;
		}
	}

	public int Score { 
		get{
			return _score;
		}
	}

	public int MaxScore {
		set{
			_maxScore = value;
		}
		get{
			return _maxScore;
		}
	}

	public int MaxMultple{
		get{
			return _maxMultiple;
		}
	}

	public int InitScore{
		get{
			return _initScore;
		}
	}
}
