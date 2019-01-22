using UnityEngine;
using System.Collections;

public class Level_Entry : BaseAction {


	public override void Awake ()
	{
		base.Awake ();

		GameObject.Find ("Direction").SetActive(false);
	}

	private void OnDrawGizmos(){
		
		Gizmos.DrawIcon(transform.position, "Gizmos_Flatland_Entry", true);
	}

	public override void Action(bool _state){

		base.Action(_state);
		
		GameObject player = (GameObject)Instantiate(Resources.Load("Base/Player"));

		player.name = "Player";
		
		player.transform.position = transform.position;
		player.transform.rotation = transform.rotation;

		player.GetComponent<DrawOnePoint>().newScene = GameObject.Find("PlayerView").GetComponent<UnityEngine.UI.Image>();

		Level_Manager.instance.player = player.transform;
	}
}
