using UnityEngine;
using System.Collections;

public class RoboTiger : Character {
	
	
	RoboTiger()
	:base("RoboTiger/",5,.15f){
		
	}
	
	// Use this for initialization
	void Start () {
		initImages();
	}
	
	// Update is called once per frame
	void Update () {
		playAnimation(0,3);
	}
}
