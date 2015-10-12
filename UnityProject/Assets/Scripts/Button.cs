﻿using UnityEngine;
using System.Collections;

public class Button : Sender {

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
}