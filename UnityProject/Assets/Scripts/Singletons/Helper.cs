using UnityEngine;
using System.Collections;

public class Helper : MonoBehaviour {

	public static Helper instance {get; private set;}

	public Color activeColor;
	public Color inactiveColor;

	public bool capture = false;

	public Color[] interactionColors;

	public ColorStates[] Interaction_Colors;
	
	private void Awake(){
		instance = this;
	}
}

[System.Serializable]
public class ColorStates {

	public Color[] color_States = new Color[3];
}
