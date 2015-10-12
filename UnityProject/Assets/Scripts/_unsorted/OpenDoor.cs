using UnityEngine;
using System.Collections;

public class OpenDoor : BaseAction {

	public GameObject linkedDoor;


	public override void Action(){

		base.Action();

		linkedDoor.SetActive(false);

//		iTween.FadeTo(this.gameObject, 0.0F, 0.8F);

		//TODO: Tigger a animation on the door. A Generic Name for the Door
		//TODO: Tigger a sound linked to the button.
		//TODO: Trigger a sound linked to opening the door.

	}
}
