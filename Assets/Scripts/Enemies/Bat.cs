using UnityEngine;
using System.Collections;

public class Bat : Character {
	
	public Transform followObj;
	
	public Bat()
	:base("Bat/",4,.15f){
		
	}
	
	
	// Use this for initialization
	void Start () {
		initImages();
	}
	
	// Update is called once per frame
	void Update () {
		

		if(transform.position.x > followObj.position.x)
			transform.position -= new Vector3(.01f, 0, 0);	
		else if(transform.position.x < followObj.position.x)
			transform.position += new Vector3(.01f, 0, 0);	
		
		if(transform.position.y < followObj.position.y)
				transform.position += new Vector3(0, .01f, 0);
		else if(transform.position.y > followObj.position.y)
				transform.position -= new Vector3(0, .01f, 0);
		
		playAnimation(0,2);	
		
	}
	
	void OnTriggerEnter(Collider c){
		if(c.gameObject.name.Equals("player")){
			print ("take megaman life");	
		}
	}
}
