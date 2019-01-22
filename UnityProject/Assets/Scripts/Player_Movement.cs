using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{

	private float currentWalkSpeed;
	public float normalWalk;
	public float fastWalk;

	private float currentStrafeSpeed;
	public float normalStrafe;
	public float fastStrafe;

	private float currentRotationSpeed; // Used as degrees per second
	public float normalRotation;
	public float fastRotation;

	private Vector3 moveVector;
	private float pushingSpeedReduction = 0.8F;
	private Transform localTransform;
	private Rigidbody localRigidbody;
	private CharacterController localCharacter;
	public ArrivingWorldIntro _linkToINTRO;
	private float pushPower = 2.0F;
	private bool rotating = false;
	private bool moving = false;
	public float movingValue = 0.0F;
	public float rotationValue = 0.0F;

	public float target_Y_position;
	public float jumpDistance = 10.0F;
	public float jumpTime = 0.2F;

	private enum soundStates
	{
		idle,
		onlyRotation,
		forward,
		back,
		rotationLeft,
		rotationRight,
		rotationIdle,

	}

	private soundStates currentSoundState;

	private Player_Stats stats;


	// Use this for initialization
	void Start ()
	{
		stats = this.GetComponent<Player_Stats>();
		localTransform = this.transform;
		localRigidbody = this.GetComponent<Rigidbody> ();
		localCharacter = this.GetComponent<CharacterController> ();

		ToggleFast (false);	
	}
	
	// Update is called once per frame
	void Update ()
	{	  

		//New Inputs
		//Get reset
		if (Input.GetKeyUp (KeyCode.W))
			MoveNew (-1);
		
		if (Input.GetKeyUp (KeyCode.S))
			MoveNew (1);
		
		if (Input.GetKeyUp (KeyCode.A))
			TurnNew (1);
		
		if (Input.GetKeyUp (KeyCode.D))
			TurnNew (-1);

		//Get Inputs
		if (Input.GetKeyDown (KeyCode.A))
			TurnNew (-1);
	   
		if (Input.GetKeyDown (KeyCode.D))
			TurnNew (1);
	   
		if (Input.GetKeyDown (KeyCode.W))
			MoveNew (1);
	   
		if (Input.GetKeyDown (KeyCode.S))
			MoveNew (-1);
	
		//Speed
		if (Input.GetKeyDown (KeyCode.LeftShift))
			ToggleFast (true);

		if (Input.GetKeyUp (KeyCode.LeftShift))
			ToggleFast (false);

		UpdateMovement();

		if(Input.GetKeyDown(KeyCode.Q)){

			Jump(-1);
		}

		if(Input.GetKeyDown(KeyCode.E)){

			Jump(1);
		}
	}

	private void Jump(int _direction){

		target_Y_position = localTransform.position.y+ jumpDistance*_direction;
//		localTransform.position = new Vector3(localTransform.position.x, localTransform.position.y+ jumpDistance*_direction*Time.deltaTime, localTransform.position.z );
	}

	private void UpdateMovement(){
	
		Vector3 _newPos = localTransform.position;
		_newPos.y = target_Y_position;

		localTransform.position = Vector3.Lerp(localTransform.position, _newPos, jumpTime );


		//Directional
		this.GetComponent<CharacterController>().Move (localTransform.forward * movingValue * currentWalkSpeed * Time.deltaTime);


		//Rotate
		localTransform.Rotate(Vector3.up * rotationValue * currentRotationSpeed * Time.deltaTime);
	
	}

	private void Sound(soundStates _newState){

		if(_newState == soundStates.forward)
			Fabric.EventManager.Instance.PostEvent("PlayerMovement", Fabric.EventAction.SetSwitch, "playerForward", gameObject);

		if(_newState == soundStates.back)
			Fabric.EventManager.Instance.PostEvent("PlayerMovement", Fabric.EventAction.SetSwitch, "playerBack", gameObject);

		if(_newState == soundStates.idle)
			Fabric.EventManager.Instance.PostEvent("PlayerMovement", Fabric.EventAction.SetSwitch, "playerIdle", gameObject);

		if(_newState == soundStates.onlyRotation)
			Fabric.EventManager.Instance.PostEvent("PlayerMovement", Fabric.EventAction.SetSwitch, "playerRotationOnly", gameObject);

		if(_newState == soundStates.rotationLeft)
			Fabric.EventManager.Instance.PostEvent("PlayerRotation", Fabric.EventAction.SetSwitch, "playerRotationLeft", gameObject);

		if(_newState == soundStates.rotationRight)
			Fabric.EventManager.Instance.PostEvent("PlayerRotation", Fabric.EventAction.SetSwitch, "playerRotationRight", gameObject);

		if(_newState == soundStates.rotationIdle)
			Fabric.EventManager.Instance.PostEvent("PlayerRotation", Fabric.EventAction.SetSwitch, "playerRotationIdle", gameObject);
	}

	private void ToggleFast (bool _state)
	{

		currentWalkSpeed = (_state) ? fastWalk : normalWalk;

		currentRotationSpeed = (_state) ? fastRotation : normalRotation;

		currentStrafeSpeed = (_state) ? fastStrafe : normalStrafe;
	}
	
	private void MoveNew (int _direction)
	{
			
		movingValue += _direction;

		if(movingValue == 1)
			Sound(soundStates.forward);
		else if(movingValue == -1)
			Sound(soundStates.back);
		else if(movingValue == 0)
			Sound(soundStates.idle);

	}

	private void Strafe (int _direction)
	{

//		moveVector += localTransform.right * _direction * walkSpeed;
		this.GetComponent<CharacterController> ().Move (localTransform.right * _direction * currentWalkSpeed * Time.deltaTime);
	}

	//Just Sound
	private void TurnNew (int _direction)
	{

		rotationValue += _direction;

		//Sound
		if(rotationValue == 1)
			Sound(soundStates.rotationRight);
		else if(rotationValue == -1)
			Sound(soundStates.rotationLeft);
		else if(rotationValue == 0){
			Sound(soundStates.rotationIdle);
			if(movingValue == 0)
				Sound(soundStates.idle);
		}

		if(rotationValue != 0 && movingValue == 0)
			Sound(soundStates.onlyRotation);
			
	}

	public void OnControllerColliderHit (ControllerColliderHit _hit)
	{
		
		Rigidbody _otherBody = _hit.collider.attachedRigidbody;
		if (_otherBody == null || _otherBody.isKinematic)
			return;
		
		if (_hit.moveDirection.y < -0.3F)
			return;
		
		Vector3 pushDir = new Vector3 (_hit.moveDirection.x, 0, _hit.moveDirection.z);
		_otherBody.velocity = pushDir * currentWalkSpeed * pushingSpeedReduction;

		//Color Issue
//		Debug.Log(localCharacter.velocity.magnitude);
		Touchable _mov = _otherBody.GetComponent<Touchable>();
		int _id = 0;

		if(_mov != null)
			if(_mov.localIC != null)
				_id = _mov.localIC.localID ;

		_mov.normalizeTimer = 1.0F;

		Debug.Log(_id);

		if(localCharacter.velocity.magnitude > 0.4F){
			
			_mov.target_Color = Helper.instance.Interaction_Colors[_id].color_States[2];
			_mov.fade_Time = 5.0F;

		}else{
			_mov.target_Color = Helper.instance.Interaction_Colors[_id].color_States[0];
			_mov.fade_Time = 0.8F;
		}
	}
}
