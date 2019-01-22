using UnityEngine;
using System.Collections;

public class Look_At_Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.LookAt(Level_Manager.instance.player.position);
	
	}
}
