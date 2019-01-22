using UnityEngine;
using System.Collections;

/// <summary>
/// Zone. Gets activated once the player enters.
/// </summary>
public class Zone : Sender {

	public bool on_Enter;
	public bool on_Exit;

	public bool on_Enter_Message = true;
	public bool on_Exit_Message = false;

	public override void Awake ()
	{
		base.Awake ();

	}

	public override void Initialize ()
	{
//		base.Initialize ();
	}

	public void OnTriggerEnter(Collider _coll){

		if(on_Enter){
			if(_coll.tag == "Player"){
			 
				Change(on_Enter_Message);
			}
		}
	}

	public void OnTriggerExit(Collider _coll){

		if(on_Exit){
			if(_coll.tag == "Player"){
			
				Change(on_Exit_Message);
			}
		}
	}
}
