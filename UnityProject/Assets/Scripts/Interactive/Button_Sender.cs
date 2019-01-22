using UnityEngine;
using System.Collections;

public class Button_Sender : Sender {

	private Moveable_Button button;

	public float startPosition;

	public bool readyForChange = true;
	public float popBackDelay = 2.0F;
	public float popBackTime = 0.7F;
//	public float 
 
	public override void Awake()
	{
		base.Awake();

		button = localTransform.Find("Moveable_Button").GetComponent<Moveable_Button>();
		startPosition = button.transform.localPosition.z;

		Fabric.EventManager.Instance.PostEvent("ButtonState", Fabric.EventAction.PlaySound, null, this.gameObject);

	}

	private void Update(){

		if(readyForChange){

			if(button.transform.localPosition.z > -0.2F){

				Change(!state);

			}
		}
	}

	public override void Change (bool _newState)
	{
		base.Change (_newState);

		readyForChange = false;
//		PopBack();
		iTween.MoveTo(button.gameObject, iTween.Hash("position", Vector3.forward * startPosition,
		                                             "delay", popBackDelay,
		                                             "time", popBackTime, 
		                                             "islocal", true, 
		                                             "easetype", iTween.EaseType.easeOutExpo,
		                                             "oncomplete", "Reset",
		                                             "oncompletetarget", this.gameObject) );
	}

	private void Reset(){

		button.transform.localPosition = Vector3.forward * startPosition;
		readyForChange = true;
	}
	 
	private void PopBack(){

		StartCoroutine(ResetReady());
	}

	private IEnumerator ResetReady(){

		while(button.transform.localPosition.z > startPosition){

			Vector3 _tempPos = button.transform.localPosition;
			_tempPos -= Vector3.forward * popBackTime * Time.deltaTime;

			button.transform.localPosition = _tempPos;

			yield return new WaitForEndOfFrame();

		}

		button.transform.localPosition = Vector3.forward * startPosition;
		readyForChange = true;
	}

	public override void ActivateSound ()
	{
		//		base.ActivateSound ();
		print (linkedIC.groupID);
		
		Fabric.EventManager.Instance.PostEvent("buttonActivate_" + linkedIC.groupID, this.gameObject);

		Fabric.EventManager.Instance.PostEvent("ButtonState", Fabric.EventAction.SetSwitch, "buttonActive_1", this.gameObject);
//		Fabric.EventManager.Instance.GetEventInfo("ButtonState", this.gameObject);
		print ("Activate");	
	}

	public override void DeactivateSound ()
	{
		//		base.ActivateSound ();
		
		Fabric.EventManager.Instance.PostEvent("buttonDeactivate_" + linkedIC.groupID, this.gameObject);
		
		Fabric.EventManager.Instance.PostEvent("ButtonState", Fabric.EventAction.SetSwitch, "buttonInactive_1", this.gameObject);
		
		print ("Deactivate");	
	}
}
