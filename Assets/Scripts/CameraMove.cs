using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	
	public Transform followObj;
	private Vector3 move = new Vector3(1,0,0);
	private float speed = 4f;
	public bool allowFollow = true;
	public bool moveCamera = false;
	public string cameraSwitch;
	private float cameraY = 1.21f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//allowFollow is the following of the camera
		if(allowFollow)
			transform.position = new Vector3(followObj.position.x, cameraY,6.5f);
		// if moveCamera is true, then it will play animation depending on which
		// Switch-## is set.
		else if(moveCamera){
			if(cameraSwitch.Equals("Switch-01")){
				camera.animation.Blend("Switch-01");
				// if alloFollow is set to true, then the cameraY position should change
				cameraY = -12;
				allowFollow = false;
			}
			moveCamera = false;
		}
			
	}
	
	
	
	void OnTriggerEnter(Collider c){
		
	}
	
	void OnCollsionEnter(Collision c){
		
	}
}
