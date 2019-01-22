using UnityEngine;
using System.Collections;

public class Moveable_Button : Moveable {

	public override void Update(){

		base.Update();

		if(localRigidbody.velocity.magnitude > 0.01F){
			//Sound
			Fabric.EventManager.Instance.PostEvent("objectMoves", Fabric.EventAction.SetVolume, 1.0F, this.gameObject);

		}else{
			Fabric.EventManager.Instance.PostEvent("objectMoves", Fabric.EventAction.SetVolume, 0.0F, this.gameObject);

		}
	}

}
