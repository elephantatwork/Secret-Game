using UnityEngine;
using System.Collections;

public class Helper : MonoBehaviour {

	public static Helper instance {get; private set;}

	public Color activeColor;
	public Color inactiveColor;

	public Color[] interactionColors;
	
	private void Awake(){
		instance = this;
	}
}
