using UnityEngine;
using System.Collections;

public class WoodMan : Character {
	
	private int r;
	private bool doAttack = false;
	private float startTime = 0;
	
	SwirlyLeafAttack swirlyAttackObj,sObj;
	FallingLeafAttack fallingLeafAttackObj;
	private bool swirlyAttackBool = true;
	
	private float timerResetOffset = 0;
	
	public WoodMan()
		:base("WoodMan/", 6, .15f){
		
	}
	
	// Use this for initialization
	void Start () {
		initImages();
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.time - startTime - timerResetOffset;
		r = Random.Range(0,5);
		
		if(r == 4){
			if(!doAttack){
				if(t > 10)
				 	resetTimer();
				doAttack = true;
			}
		}
		
		if(doAttack){
			if(t < 2){
				if(swirlyAttackBool){
					swirlyAttackObj = Instantiate(Resources.Load("AttackObj/SwirlyLeafAttack")) as SwirlyLeafAttack;
					
					swirlyAttackBool = false;
				}
				playAnimation(1,2);
			}
			else if(t > 2 && t < 3){
				setFrame(3);	
			}else if(t > 3 && t < 4){
				setFrame(4);
				//GameObject.Find("SwirlyLeafAttack").GetComponent<SwirlyLeafAttack>().fireAttack();
				FallingLeafAttack fallingLeaf = FindObjectOfType(typeof(FallingLeafAttack))as FallingLeafAttack;
				fallingLeaf.fireAttack();
				sObj = FindObjectOfType(typeof(SwirlyLeafAttack)) as SwirlyLeafAttack;
				sObj.fireAttack();
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
