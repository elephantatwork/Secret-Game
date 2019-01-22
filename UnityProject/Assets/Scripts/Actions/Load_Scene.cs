using UnityEngine;
using System.Collections;

[System.Serializable]
public class Load_Scene : BaseAction {
	
//	public string[] allScenes;
	public string sceneName;

	//TODO: Get all scene names and select your level through a dropdown

	public override void Action (bool _state)
	{
		base.Action (_state);

		Application.LoadLevel(sceneName);
	}
	
}
