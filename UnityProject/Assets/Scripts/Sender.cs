using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sender : Interactive {

//	public GameObject activeObject;
//	public List<GameObject> activeMarkers;


	public override void Awake ()
	{
		base.Awake ();

	}

	public void Initialize(){
		Change (state);
	}

	private void OnMouseDown(){

		Change(!state);
	}

	public override void Change (bool _newState)
	{
		base.Change (_newState);

		linkedIC.GetChange(localID, state);

	}

//	public override void Activate ()
//	{
//		for(int i = 0; i < activeObjects.Count; i++){
//
//			activeObjects[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
//
//			iTween.StopByName(activeObjects[i], "colorActive");
//			iTween.ColorTo(activeObjects[i],iTween.Hash("name", "colorActive", "color", Color.white, "time",colorTranisitonTime, "includeChildren", false));
//		}
//
//		for(int i = 0; i < activeMarkers.Count; i++){
//
//			activeMarkers[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", linkedStateControll.groupColor);
//
//			iTween.StopByName(activeMarkers[i], "colorActive");
//			iTween.ColorTo(activeMarkers[i], iTween.Hash("name", "colorActive", "color", linkedStateControll.groupColor, "time",colorTranisitonTime));
//		}
//	}
//
//	public override void Deactivate ()
//	{
//		for(int i = 0; i < activeObjects.Count; i++){
//		
//			activeObjects[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", linkedStateControll.groupColor);
//
//			iTween.StopByName(activeObjects[i], "colorActive");
//			iTween.ColorTo(activeObjects[i],iTween.Hash("name", "colorActive", "color", linkedStateControll.groupColor, "time",colorTranisitonTime, "includeChildren", false));
//		}
//
//		for(int i = 0; i < activeMarkers.Count; i++){
//
//			activeMarkers[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
//			
//			iTween.StopByName(activeMarkers[i], "colorActive");
//			iTween.ColorTo(activeMarkers[i], iTween.Hash("name", "colorActive", "color", Color.white, "time",colorTranisitonTime));
//		}
//	}
}
