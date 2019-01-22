using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Narrator : MonoBehaviour {

	public static Narrator instance {get; private set;}
	private Collider old_Selected_Object;

	public float Collider_Distance = 30.0F;

	private Transform narration_Object;


	private float correctDirection = 0.5F;

	// Use this for initialization
	void Awake () {

		instance = this;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)){

			Raycast_Scene();
		}

		if(Input.GetKeyDown(KeyCode.Z)){

			GetCardinal();
		}
	}

	public void Raycast_Scene(){

		Ray ray = new Ray(transform.position, transform.forward);
		int _layer = 1 << LayerMask.NameToLayer("Level");
		RaycastHit hit;

		narration_Object = null;

		if(Physics.Raycast(ray, out hit, Collider_Distance, _layer)){

			if(hit.collider != old_Selected_Object){

				narration_Object = hit.transform;
			}

		}

		//Trigger
		_layer = 1 << LayerMask.NameToLayer("Narration_Trigger");

		if(Physics.Raycast(ray, out hit, Collider_Distance, _layer)){
			
			if(hit.collider != old_Selected_Object){

				if(narration_Object != null){
//					float _colliderDistance = narration_Object
//					float _triggerDistance = 

				}
				//No Collider Found in the first place
				else{

					narration_Object = hit.transform;

				}
			}
		}
	
		if(narration_Object != null){

			Story _story = narration_Object.GetComponent<Story>();

			if(_story != null){
				string _entry = _story.GetStory();
				Text_Manager.instance.AddText(false, _entry);

			}
			else{
				GetCardinal();
			}

		}
		//If still no narraction Object
		else{
		

			GetCardinal();

		}



//		for(int i = 0; i < hits.Length; i++){
//
//			Debug.Log(hits[i].collider.name);
//
//			if(hits[i].collider != old_Selected_Object ){
//
//				//If normal Collider
//				if(!hits[i].collider.isTrigger){
//					float _colDist = (hits[i].transform.position - transform.position).magnitude;
//					
//					if(_colDist < Collider_Distance){
//						cleanList.Add(hits[i].collider);
//					}
//				}
//			}
//		}
	}

	private void GetCardinal(){

		Vector3 _car = transform.forward.normalized;

		print (_car);

		if(_car.x >= 0){

			if(_car.z < -1+correctDirection)
				Text_Manager.instance.AddText(true, "WEST");
			else if(_car.z > 1-correctDirection)
				Text_Manager.instance.AddText(true, "EAST");
			else
				Text_Manager.instance.AddText(true, "NORTH");


		}else{

			if(_car.z < -1+correctDirection)
				Text_Manager.instance.AddText(true, "WEST");
			else if(_car.z > 1-correctDirection)
				Text_Manager.instance.AddText(true, "EAST");
			else
				Text_Manager.instance.AddText(true, "SOUTH");

		}
	}

	public string RandomQuote(){

		return "I've looked at that before";
	}
}
