using UnityEngine;
using System.Collections;

public class Level_Manager : MonoBehaviour {

	public static Level_Manager instance {get; private set;}
	
	public Transform player;

	// Current Level
	private Transform level_Parent;
	private Transform entry_Point;
//	private Transform


	private void Awake(){
		instance = this;
	}

	private void Start(){
		StartLevel();
	}

	// Use this for initialization
	public void StartLevel () {

		level_Parent = GameObject.Find("Level").transform;
		entry_Point = level_Parent.Find("Entry");

		entry_Point.GetComponent<Level_Entry>().Action(true);
	
	}

}
