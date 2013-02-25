
using UnityEngine;
using System.Collections;

public class playerControls : MonoBehaviour {
	

private Texture[] textures;

private Material goMaterial;
	

	
public int frame = 0;
private int frameStart = 0;
public int frameEnd = 0;
private int frameCounter = 0;
	
private int fire2FrameStart = 0;
private int fire2FrameEnd = 3;
	
bool fire2release = true;
bool attackFinished = false;
	
public int direction;
	
//ArrayList images;

private ArrayList runAnimations_list = new ArrayList();
	
private Texture[] runAnimations;
	
private Vector3 rightImageSide = new Vector3(30f,180f,0f);
private Vector3 leftImageSide = new Vector3(30f,180f,180f);
	
	
private bool characterPosMove = false;		

float runSpeed      = 4.0f;												 					  //speed of run
float runJump       = 10.5f;												  					  //jump height from run
float gravity       = 30.0f;																  //force applied on char
float startPos	    = 0.0f;																	  //Location of starting position
int moveDirection   = 1;																	  //facing right is 1, facing left is 0
	
private Vector3 velocity = Vector3.zero;      												  // speed of player and direction
	
	void Awake(){
		this.goMaterial = renderer.material;	
	}
	
	static ArrayList addImage(string dir, int size){
		ArrayList images = new ArrayList();
		
		for(int x = 0; x < size; x++){
			images.Add(Resources.Load(dir+x, typeof(Texture)));
		}
		return images;
	}
	
	// Use this for initialization
	void Start () {
		

		runAnimations = addImage("MegaMan/", 32).ToArray(typeof(Texture)) as Texture[];
		
		
		
		
	}
	
	
	
	
    void Update() {																			//Update
		
		
		
        CharacterController controller = GetComponent<CharacterController>();
		
		velocity.y -= gravity * Time.deltaTime;
		
		
		if ( velocity.x == 0 && controller.isGrounded && moveDirection == 1){				//idle right
			
			goMaterial.mainTexture = (Texture)runAnimations[18];
			
		}

		if ( velocity.x == 0 && controller.isGrounded && moveDirection == 0){				//idle left
			
			goMaterial.mainTexture = (Texture)runAnimations[4];
		}

    	
    	
    	if (controller.isGrounded && Input.GetButton("Jump")){								//Jump
    		
    		velocity.y = runJump;
    	}
		
    	if(!controller.isGrounded && moveDirection == 0){									//left facing jump animation
			goMaterial.mainTexture = (Texture)runAnimations[10];
		}
    	
		if(!controller.isGrounded && moveDirection == 1){									//right facing jump animation
			goMaterial.mainTexture = (Texture)runAnimations[24];
		}
   
    
    	velocity.x = Input.GetAxis("Horizontal");
    	velocity.x *= runSpeed;
    	
    
    
    if( velocity.x < 0){																	//check if facing left
    	moveDirection = 0;
			
		if(controller.isGrounded){															//left run animation
			animMoveCharacter(7,9);
			
		}
		
    }
    
    if( velocity.x > 0){																	//check if facing right
    	moveDirection = 1;
		
		if(controller.isGrounded){															//right run animation
			animMoveCharacter(21,23);
				
		}
    }
    
    
    controller.Move( velocity * Time.deltaTime);
        
		
}
	void animMoveCharacter(int fStart, int fEnd){											//Animation frameset method
		
		
		frameEnd = fEnd;
		frameStart = fStart;
		StartCoroutine("PlayLoop", .1);
		goMaterial.mainTexture = (Texture)runAnimations[frameCounter];
	}
	
	IEnumerator PlayLoop(float delay){  													//Loop animation with delay between frames
            //Wait for the time defined at the delay parameter  
            yield return new WaitForSeconds(delay);    
      
            //Advance one frame  
            frameCounter = (++frameCounter)% runAnimations.Length;  
		
			// reset to the begining of the animation
			if(frameCounter < frameStart || frameCounter > frameEnd){
				frameCounter = frameStart;
			}
      
            //Stop this coroutine  
            StopCoroutine("PlayLoop");  
    } 
	
	
}