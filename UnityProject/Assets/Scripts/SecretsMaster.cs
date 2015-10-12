using UnityEngine;
using System.Collections;

public class SecretsMaster : MonoBehaviour {

	public static SecretsMaster instance {get; private set;}

	public InteractiveCore[] allStateControlls;
	public GameObject player;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {

		//Create new SafeState
		SafeState.current = new SafeState();


	
		player = GameObject.Find("Player");
		allStateControlls = GameObject.Find("Game").GetComponentsInChildren<InteractiveCore>();

//		LoadState();
	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown(KeyCode.K)){

//			allStateControlls = GameObject.Find("Game").GetComponentsInChildren<StateControll>();
			SaveGame();



		}

		if(Input.GetKeyDown(KeyCode.L)){



			LoadState();
		}
	}

	public void LoadState(){

		SaveManager.Load();
//		for(int i = 0; i < allStateControlls.Length; i++){
//
////			allStateControlls[i] = SaveManager.savedStates.level.allStateControlls[i];
//
//		}
//		player = GameObject.Find("Player");
		Vector3 _savedPosition = new Vector3(SaveManager.savedState.player.posX, SaveManager.savedState.player.posY, SaveManager.savedState.player.posZ);		print (_savedPosition);
		player.transform.position = _savedPosition;

//		SaveManager.savedStates
	}

	public void SaveGame(){

		Debug.Log("Hello" + player);

		Vector3 _playerPos = player.transform.position;

		print (_playerPos);

		SafeState.current.player.posX = _playerPos.x;
		SafeState.current.player.posY = _playerPos.y;
		SafeState.current.player.posZ = _playerPos.z;

		//Save to file
		SaveManager.Save();
	}
}
