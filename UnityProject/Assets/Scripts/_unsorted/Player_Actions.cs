using UnityEngine;
using System.Collections;

public class Player_Actions : MonoBehaviour {

	private Player_Stats stats;

	// Use this for initialization
	void Awake () {
	
		this.GetComponent<Player_Stats>();

	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Space)){

		}
	}

	private void ActionA(){

	}

	private void ActionB(){
		
	}

	private void ColorInteraction(){

		//Player is neutral / white
		if(stats.currColorValue == Color.white){

			//Grab Color

			//Is in Color Pick Up Zone?

		}
		//Player has color
		else{

			//Drop Color
		}
	}

}
