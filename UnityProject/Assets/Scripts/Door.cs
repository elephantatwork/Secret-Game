using UnityEngine;
using System.Collections;

public class Door : Reciever {


//	public Transform[] doorSides;
//
//	public Vector3[] doorOpenPosition;
//	public Vector3[] doorClosedPosition;
	private Animator localAnimator;

	public override void Awake(){

		base.Awake();

		localAnimator = this.GetComponent<Animator>();
	}

	public override void Activate ()
	{
		base.Activate ();

//		for(int i = 0; i < doorSides.Length; i++){
//
//			doorSides[i].localPosition = activeMarkers[i].localPosition;

//		}
		localAnimator.SetBool("open", true);
	}

	public override void ActivateSound ()
	{
//		base.ActivateSound ();
		
		Fabric.EventManager.Instance.PostEvent("doorActivate_" + linkedIC.groupID, this.gameObject);
		
		Fabric.EventManager.Instance.PostEvent("DoorState", Fabric.EventAction.SetSwitch, "doorActive_" + linkedIC.groupID, this.gameObject);
			

	}

	public override void Deactivate ()
	{
		base.Deactivate ();

		localAnimator.SetBool("open", false);
	}

	public override void DeactivateSound ()
	{
//		base.ActivateSound ();
		
		Fabric.EventManager.Instance.PostEvent("doorDeactivate_" + linkedIC.groupID, this.gameObject);
		
		Fabric.EventManager.Instance.PostEvent("DoorState", Fabric.EventAction.SetSwitch, "doorInactive_" + linkedIC.groupID, this.gameObject);
		
		
	}
}
