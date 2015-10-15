using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interactive : MonoBehaviour {

	public List<GameObject> activeObjects;
	public List<GameObject> activeMarkers;

	public Material interactiveMaterial;

	public int localID;
	public Transform localTransform;
	public bool state;
	
	public InteractiveCore linkedStateControll;

	private float colorTranisitonTime = 0.8F;
	private Renderer localRenderer;

	public virtual void Awake () {

		localTransform = this.transform;
		localRenderer = this.GetComponent<Renderer>();

		interactiveMaterial = Resources.Load("Interactive") as Material;

		Transform[] _allTransforms = this.GetComponentsInChildren<Transform>();

		for(int it = 0; it < _allTransforms.Length; it ++){

			if(_allTransforms[it].tag == "Interactive"){

				_allTransforms[it].GetComponent<Renderer>().material = interactiveMaterial;

				activeObjects.Add(_allTransforms[it].gameObject);
			}
		}

//		if(activeObjects.Count <= 0){
//
//			activeObjects = new GameObject[1]{this.gameObject};
////			activeObjects[0] = this.gameObject;
//		}
		
		activeMarkers = new List<GameObject>();
		
		Transform[] _allChildren = this.GetComponentsInChildren<Transform>();
		
		for(int i = 0; i < _allChildren.Length; i++){
			
			if(_allChildren[i].name == "ActiveMarker"){

				_allChildren[i].GetComponent<Renderer>().material = interactiveMaterial;

				activeMarkers.Add(_allChildren[i].gameObject);

			}
		}	
	}

	private void OnDrawGizmos(){

		Gizmos.DrawIcon(this.transform.position, "Gizmos_Flatland_" + this.name + "_" + state.ToString(), true);
	}
	
	public virtual void Change(bool _newState){

		string _state = (_newState) ? "active" : "inactive";
		Debug.Log("Core " + linkedStateControll.name + ", Object :" + this.name + " is now " + _state);

		state = _newState;

		if(state)
			Activate();
		else
			Deactivate();
	}
	
	// Update is called once per frame
	public virtual void Activate ()
	{
		for(int i = 0; i < activeObjects.Count; i++){
			
			activeObjects[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
			
			iTween.StopByName(activeObjects[i], "colorActive");
			iTween.ColorTo(activeObjects[i],iTween.Hash("name", "colorActive", "color", Color.white, "time",colorTranisitonTime, "includeChildren", false));
		}
		
		for(int i = 0; i < activeMarkers.Count; i++){
			
			activeMarkers[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", linkedStateControll.groupColor);
			
			iTween.StopByName(activeMarkers[i], "colorActive");
			iTween.ColorTo(activeMarkers[i], iTween.Hash("name", "colorActive", "color", linkedStateControll.groupColor, "time",colorTranisitonTime));
		}

		ActivateSound();


	}

	public virtual void ActivateSound(){

		Fabric.EventManager.Instance.PostEvent("objectActivate", this.gameObject);
		
		Fabric.EventManager.Instance.PostEvent("InteractiveState", Fabric.EventAction.SetSwitch, "objectActive", this.gameObject);

	}
	
	public virtual void Deactivate ()
	{

		for(int i = 0; i < activeObjects.Count; i++){
			
			activeObjects[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", linkedStateControll.groupColor);
			
			iTween.StopByName(activeObjects[i], "colorActive");
			iTween.ColorTo(activeObjects[i],iTween.Hash("name", "colorActive", "color", linkedStateControll.groupColor, "time",colorTranisitonTime, "includeChildren", false));
		}
		
		for(int i = 0; i < activeMarkers.Count; i++){
			
			activeMarkers[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
			
			iTween.StopByName(activeMarkers[i], "colorActive");
			iTween.ColorTo(activeMarkers[i], iTween.Hash("name", "colorActive", "color", Color.white, "time",colorTranisitonTime));
		}

		DeactivateSound();

	}

	public virtual void DeactivateSound(){

		//Sound
		Fabric.EventManager.Instance.PostEvent("objectDeactivate", this.gameObject);
		
		Fabric.EventManager.Instance.PostEvent("InteractiveState", Fabric.EventAction.SetSwitch, "objectInactive", this.gameObject);

	}

}
