﻿using UnityEngine;
using System.Collections;

public class InteractiveCore : MonoBehaviour {
	
	public Sender[] allSenders;
	public Reciever[] allRecievers;
	
	public enum interactiveType{

		toggle,
		single,
		help
	}

	public interactiveType interactive_Type;

	public Color groupColor;
	public int groupID = 1; // 1, 2 or 3

	public bool groupState;

	private void Awake(){

//		print(Helper.instance);
		groupID = 1;

		groupColor = Helper.instance.interactionColors[Random.Range(0,Helper.instance.interactionColors.Length)];
	}

	private void Start(){

//		groupColor = Helper.instance.interactionColors[Random.Range(0,Helper.instance.interactionColors.Length)];

		//Search all Recievers
		allRecievers = this.GetComponentsInChildren<Reciever>();
		
		//Link to Recievers
		for(int i = 0; i < allRecievers.Length; i++){

//			for(int ia = 0; ia < allRecievers[i].activeObjects.Count; ia ++){


//				allRecievers[i].activeObjects[ia].GetComponent<Renderer>().material.color = groupColor;

			allRecievers[i].localID = i;
			allRecievers[i].linkedIC = this;

			allRecievers[i].Initialize();
//			allRecievers[i].Change(allRecievers[i].state);
//			}
		}

		//Search all Recievers
		allSenders = this.GetComponentsInChildren<Sender>();

		//Link to Senders
		for(int ii = 0; ii < allSenders.Length; ii++){

//			for(int iia = 0; iia < allSenders[ii].activeObjects.Count; iia ++){

//				allSenders[ii].activeObjects[iia].GetComponent<Renderer>().material.color = groupColor;

//				allSenders[ii].Change(allSenders[ii].state);
//			}

			allSenders[ii].localID = ii;
			allSenders[ii].linkedIC = this;

			allSenders[ii].Initialize();
		}
	}

	//Toggle Way
	public void GetChange(int _localID, bool _newState){

		switch(interactive_Type){

			//all senders contribute to the group state which is represented by all recievers
			case interactiveType.toggle:

				bool _currentState = CheckSenders();

				if(groupState != _currentState){

					groupState = _currentState;

					for(int i = 0; i < allRecievers.Length; i++){
						allRecievers[i].Change(groupState);
					}	
				}
				break;

			//one sender changes everything
			case interactiveType.single:

				for(int i = 0; i < allRecievers.Length; i++){
					allRecievers[i].Change(_newState);
				}	

			break;
		}
	}

	private bool CheckSenders(){

		for(int i = 0; i < allSenders.Length; i++){

			if(!allSenders[i].state)
				return false;
		}

		return true;
	}

	//Link all partners
	private void OnDrawGizmos(){

		//Main Guizmo
		Gizmos.DrawIcon(this.transform.position, "Gizmos_Flatland_" + this.name + "_" + groupState.ToString(), true);
		
		for(int i = 0; i < allRecievers.Length; i++){
			//			allRecievers.
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(this.transform.position, allRecievers[i].transform.position);
		}
		
		//Link to Senders
		for(int ii = 0; ii < allSenders.Length; ii++){

			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(this.transform.position, allSenders[ii].transform.position);
			
		}

	}
}
