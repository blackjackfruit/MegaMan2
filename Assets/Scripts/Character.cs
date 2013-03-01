using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	private int health;
	private int attack;
	private int frameStart,frameEnd;
	private string directoryPath;
	private int directorySize;
	private Texture[] charAnimations;
	private int frameCounter = 0;
	private float delay;
	
	private Material materialForPlane;
	
	public int Health{
		set {
			health = value;
		}
		get {
			return health;	
		}
	}
	public int Attack{
		set {
			attack = value;	
		}
		get {
			return attack;	
		}
	}
	
	void Awake(){
		this.materialForPlane = renderer.material;
	}
	
	public Character(string dir, int s, float d){
		
		this.directoryPath = dir;
		this.directorySize = s;
		this.delay = d;
		
	}
	
	public void initImages(){
		//print("Initialized " + directoryPath);
		ArrayList images = new ArrayList();
		for(int x = 0; x < directorySize; x++){
			images.Add(Resources.Load(directoryPath+x, typeof(Texture)));
			print ("img "+ directoryPath+x);
		}
		charAnimations = images.ToArray(typeof(Texture)) as Texture[];
	}
	
	public void playAnimation(int fStart, int fEnd){											//Animation frameset method
		//print(charAnimations.Length);
		frameEnd = fEnd;
		frameStart = fStart;
		StartCoroutine("PlayLoop", delay);
		materialForPlane.mainTexture = (Texture)charAnimations[frameCounter];
	}
	
	IEnumerator PlayLoop(float d){  													//Loop animation with delay between frames
            //Wait for the time defined at the delay parameter  
            yield return new WaitForSeconds(d);    
            //Advance one frame  
            frameCounter = (++frameCounter)% charAnimations.Length;  
		
			// reset to the begining of the animation
			if(frameCounter < frameStart || frameCounter > frameEnd){
				frameCounter = frameStart;
			}
      
            //Stop this coroutine  
            StopCoroutine("PlayLoop");  
    } 
	public int getFrame(){
		return frameCounter;	
	}
	public void addOneFrame(){
		frameCounter++;
		print ("t " + frameCounter);
		// reset to the begining of the animation
		if(frameCounter < frameStart || frameCounter > frameEnd){
			frameCounter = frameStart;
		}
		materialForPlane.mainTexture = (Texture)charAnimations[frameCounter];
	}
	public void setFrame(int f){
		frameCounter = f;
		materialForPlane.mainTexture = (Texture)charAnimations[frameCounter];
	}
	public void resetToStartFrame(){
		frameCounter = 0;	
	}
}
