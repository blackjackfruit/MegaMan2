using UnityEngine;
using System.Collections;

public class WoodMan : Character {
	
	public Transform followObj;
	
	// direction is the variable to control which direction woodman will jump towards.
	// if it is -1, he will jump towards the left. if it is 1 he will jump to the right.
	private short direction = -1;
	private int r;
	private bool doAttack = false;
	private float startTime = 0;
	private float t;
	private bool endJump = false;
	private bool doJump = false;
	
	private float fallSpeed = 13,jumpSpeed = 10;
	private float dTime;
	
	private CharacterController woodMan;
	
	private SwirlyLeafAttack sObj;
	private GameObject swirlyAttackObj;
	private FallingLeafAttack fallingLeafAttackObj;
	private bool swirlyAttackBool = true;
	
	private float timerResetOffset = 0;
	
	public WoodMan()
		:base("WoodMan/", 7, .15f){
	}
	
	// Use this for initialization
	void Start () {
		initImages();
		woodMan = GetComponent<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		dTime = Time.deltaTime;
		t = Time.time - startTime - timerResetOffset;
		
		if(woodMan.isGrounded)
			if(doAttack)
				attack();
			else if(Random.Range(0,29) == 1){
				if(!doJump)
					doAttack = true;
			}
			else if(Random.Range(0,30) == 1){
				if(!doAttack)
					doJump = true;
			}
		if(doJump)
			jump();
		else if(doAttack)
			attack();
		else 
			initGround();
		
		
	}
	private void initGround(){
		woodMan.Move(new Vector3(0,(-1)*dTime*fallSpeed,0));
	}
	
	private void jump(){
		doJump = true;
		if(t < 1){
			endJump = false;
			setFrame(3);
		}else if(t > 1 && t < 1.4){
			if(!endJump){
				woodMan.Move(new Vector3(direction*dTime,jumpSpeed*dTime,0));
			}
			if(transform.position.y >= -25)
					endJump = true;
			setFrame(6);
		}
		else {
			woodMan.Move(new Vector3(direction*dTime,(-1)*dTime*fallSpeed,0));
			if(woodMan.isGrounded == true){
				rotateCharacter();
				setFrame(0);
				endJump = false;
				doJump = false;
				resetTimer();
			}
		}
	}
	
	
	// this method is called to flip the character plane
	private void rotateCharacter(){
		
		if((followObj.transform.position.x > transform.position.x) && ((int)transform.eulerAngles.y == 180)){
			//transform.eulerAngles = new Vector3(90,0,0);
			transform.eulerAngles = new Vector3(90,0,0);
			transform.position = new Vector3(transform.position.x, transform.position.y, 14.8f);
			direction *= -1;
		}
		else if((followObj.transform.position.x < transform.position.x) && ((int)transform.eulerAngles.y == 0)){
			transform.eulerAngles = new Vector3(90,180,0);
			transform.position = new Vector3(transform.position.x, transform.position.y, 14.8f);
			direction *= -1;
		}
		
	}
	
	private void attack(){
		if(!doAttack){
			if(t > 6)
			 	resetTimer();
			doAttack = true;
		}
		
		
		if(doAttack){
			if(t < 2){
				if(swirlyAttackBool){
					swirlyAttackObj = Instantiate(Resources.Load("AttackObj/SwirlyLeafAttack")) as GameObject;
					swirlyAttackObj.GetComponent<SwirlyLeafAttack>().setVariables((int)transform.position.x, direction);
					swirlyAttackBool = false;
				}
				playAnimation(1,2);
			}
			else if(t > 2 && t < 3){
				setFrame(3);	
			}else if(t > 3 && t < 4.5){
				setFrame(4);
				//GameObject.Find("SwirlyLeafAttack").GetComponent<SwirlyLeafAttack>().fireAttack();
				swirlyAttackObj.GetComponent<SwirlyLeafAttack>().fireAttack();
			}else {
				doAttack = false;	
				setFrame(0);
				swirlyAttackBool = true;
			}
		}
	}
	
	public void resetTimer(){
		timerResetOffset = Time.time;
	}
}
