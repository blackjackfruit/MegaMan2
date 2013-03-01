using UnityEngine;
using System.Collections;

public class MegaMan : Character {
	
	public MegaMan()	
	:base("MegaMan/",18,.5f){
		
	}
	
	// Use this for initialization
	void Start () {
		initImages();
	}
	
	// Update is called once per frame
	void Update () {
		playAnimation(7,10);
	}
}
