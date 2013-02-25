using UnityEngine;
using System.Collections;


public class BossSelectAnimation : Character {
	
	private float timeStarted;
	
	public BossSelectAnimation()
		:base("WoodMan/",3,.15f){
		
	}
	
	// Use this for initialization
	void Start () {
		initImages();
		timeStarted = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
		if((Time.time - timeStarted) < 5){
			playAnimation(0,2);
		}else {
			setFrame(0);
		}
		if(GameObject.FindGameObjectWithTag("MainCamera").audio.isPlaying == false){
			Application.LoadLevel("WoodManLevel");
		}
	}
	
}
