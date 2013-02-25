using UnityEngine;
using System.Collections;

public class Bunny : Character {
	
	public Transform followObj;
	
	private bool isJump = false;
	private bool lastFrame = false;
	
	CharacterController charController;
	private Vector3 velocity = Vector3.zero;
	Bunny()
	:base("Bunny/",3,.15f)
	{
		
	}
	
	// Use this for initialization
	void Start () {
		initImages();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		velocity.y -= 1f * Time.deltaTime;		
		
		
		if(Random.Range(0,70) == 4){
			if(!isJump){
				rigidbody.position += new Vector3(0,2,0);	
				isJump = true;	
			}
		}
		if(isJump){
			if(getFrame() == 0){	
				setFrame(1);
			}else {
				setFrame(2);	
			}
			
			if(transform.position.x > followObj.position.x)
				rigidbody.position -= new Vector3(.01f, 0, 0);	
			else if(transform.position.x < followObj.position.x)
				rigidbody.position += new Vector3(.01f, 0, 0);	
			
		}
		
		//print(getFrame());
	}
	
	void OnCollisionEnter(Collision c){
		if(c.gameObject.name.Equals("Ground")){
			setFrame(0);
			isJump = false;
		}
	}
}
