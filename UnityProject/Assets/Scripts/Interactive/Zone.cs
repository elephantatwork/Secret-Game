using UnityEngine;
using System.Collections;

/// <summary>
/// Zone. Gets activated once the player enters.
/// </summary>
public class Zone : Sender {

	public override void Awake ()
	{
		base.Awake ();

//		int layerMask = 1 << LayerMask.NameToLayer("Zone");

//		for(int i = 0; i < activeObjects.Count; i++){
//			activeObjects[i].layer = LayerMask.NameToLayer("Zones")	;
//		}
	}

	public void OnTriggerEnter(Collider _coll){

		if(_coll.tag == "Player"){
			 
//			Activate();
			Change(true);
		}
	}

	public void OnTriggerExit(Collider _coll){

		if(_coll.tag == "Player"){
			
//			();
			Change(false);
		}
	}
}
