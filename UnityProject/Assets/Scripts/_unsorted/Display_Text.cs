using UnityEngine;
using System.Collections;

public class Display_Text : BaseAction {

	public bool passed = false;
	public bool newEntry = false;

	public string text;

	public override void Awake ()
	{
		base.Awake ();


	}

	public override void Action (bool _state)
	{
		base.Action (_state);
	
		if(passed)
			return;

		Text_Manager.instance.AddText(newEntry, text);

		passed = true;

	}
}
