using UnityEngine;
using System.Collections;

enum ObjectType{
	
};

public class RandomObject : MonoBehaviour {

	public GameObject bloodObj;
	public GameObject sprintObj;
	public GameObject protectionObj;

	private ArrayList objects;

	void Start () {
		objects = new ArrayList();
	}

	void Update () {
		
	}
}
