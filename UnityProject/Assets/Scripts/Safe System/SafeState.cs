using UnityEngine;
using System.Collections;

[System.Serializable]
public class SafeState  {
	
	public static SafeState current;
	public PlayerState player;
//	public LevelState level;

	//Stats
//	public float timePlayed = 0.0F;

	public SafeState() {

//		current = new SafeState();
//		allLevels = new List<LevelState>();
//		level = new LevelState();
		player = new PlayerState();
	}
}

//[System.Serializable]
//public class LevelState {
//
//	public int id;
//	public StateControll[] allStateControlls;
//
//	public LevelState(){
//
//
////		id = Application.loadedLevel;
//
////		allStateControlls = ;
//	}
//}


