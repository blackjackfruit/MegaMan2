
using UnityEngine;
using System.Collections;

public class playerControls : Character {
	

private Texture[] textures;
private Transform thisTransform;

	
private int fire2FrameStart = 0;
private int fire2FrameEnd = 3;
	
	
public int direction;
	
//ArrayList images;

private ArrayList runAnimations_list = new ArrayList();
	
private Texture[] runAnimations;
	
private Vector3 rightImageSide = new Vector3(90f,180f,0f);
private Vector3 leftImageSide = new Vector3(90f,0f,0f);
	
	
		

float runSpeed      = 5.0f;												 					  										//speed of run
float airSpeed      = 4.0f;												 					  										//speed of megaman while in the air
float runJump       = 10.5f;												  				  										//jump height from run
float gravity       = 30.0f;																  										//force applied on char
float gravityFall   = -100;
float falling	    = 0.0f;																	  										//Location of starting position
int moveDirection   = 1;																	  										//facing right is 1, facing left is 0
	
private Vector3 velocity = Vector3.zero;      												  										// speed of player and direction
	
private float bulletCounter;
private GameObject bullet;

	public playerControls()
	:base("MegaMan/",18,.15f){
		
	}
	
	// Use this for initialization
	void Start () {
		

		initImages();
		
		
	}
	
	
	
	
    void Update() {																													//Update
		
		
		
        CharacterController controller = GetComponent<CharacterController>();
		velocity.x = Input.GetAxis("Horizontal");
		thisTransform = transform;
		
		if(Input.GetButton("Fire2")){																								//Shooting	
			if(bulletCounter > .1f){
				bullet = Instantiate(Resources.Load("Attack/Bullet")) as GameObject;
				bullet.transform.position = new Vector3(transform.position.x, transform.position.y,0);
				bulletCounter = 0;
			}
			bulletCounter += Time.deltaTime;			
							
		}
		
		if(velocity.x == 0 && controller.isGrounded && moveDirection == 0 && Input.GetButton ("Fire2")){							//still shooting left
		
				transform.eulerAngles = leftImageSide;
				setFrame(14);
			
		}
		if(velocity.x == 0 && controller.isGrounded && moveDirection == 1 && Input.GetButton ("Fire2")){							//still shooting right
				transform.eulerAngles = rightImageSide;
				setFrame(14);
			
		}		
		if(!controller.isGrounded && moveDirection == 0 && Input.GetButton ("Fire2")){												//air shooting left
				transform.eulerAngles = leftImageSide;
				setFrame(12);
			
		}			
		if(!controller.isGrounded && moveDirection == 1 && Input.GetButton ("Fire2")){												//air shooting right
				transform.eulerAngles = rightImageSide;
				setFrame(12);
			
		}	
		
		if (controller.isGrounded){																									//Falling
    		
    		velocity.y = gravityFall* Time.deltaTime;
			velocity.x *= airSpeed;
    	}
		
		if ( velocity.x == 0 && controller.isGrounded && moveDirection == 1 && !Input.GetButton ("Fire2")){							//idle right
			
			transform.eulerAngles = rightImageSide;
			setFrame(4);
		}

		if ( velocity.x == 0 && controller.isGrounded && moveDirection == 0 && !Input.GetButton ("Fire2")){							//idle left
			transform.eulerAngles = leftImageSide;
			setFrame(4);
		}

    	
    	
    	if (controller.isGrounded && Input.GetButtonDown("Jump") && !Input.GetButton ("Fire2")){									//Jump
    		setFrame(10);
    		velocity.y = runJump;
    	}
		
		if (!controller.isGrounded){																								//Falling
    		setFrame(10);
    		velocity.y -= gravity * Time.deltaTime;
			velocity.x *= airSpeed;
    	}
		
    	if(!controller.isGrounded && moveDirection == 0 && !Input.GetButton ("Fire2")){												//left facing jump animation
			transform.eulerAngles = leftImageSide;
			setFrame(10);
			
		}
    	
		if(!controller.isGrounded && moveDirection == 1 && !Input.GetButton ("Fire2")){												//right facing jump animation
			transform.eulerAngles = rightImageSide;
			setFrame(10);
		}
   
    
    	
    	
    
    
    if( velocity.x < 0){																											//check if facing left
    	moveDirection = 1;
			
		if(controller.isGrounded && !Input.GetButton ("Fire2")){																	//left run animation
			transform.eulerAngles = rightImageSide;
			playAnimation(7,9);
			
		}
		if(controller.isGrounded && Input.GetButton ("Fire2")){																		//left run shoot animation
			transform.eulerAngles = rightImageSide;
			playAnimation(15,17);
			
		}
    }
    
    if( velocity.x > 0){																											//check if facing right
    	moveDirection = 0;	
		
		if(controller.isGrounded && !Input.GetButton ("Fire2")){																	//right run animation
			transform.eulerAngles = leftImageSide;
			playAnimation(7,10);
				
		}
		if(controller.isGrounded && Input.GetButton ("Fire2")){																		//right run shoot animation
			transform.eulerAngles = leftImageSide;
			playAnimation(15,17);
			
		}

    }
    
   
    controller.Move( velocity * Time.deltaTime);    
		
}
}