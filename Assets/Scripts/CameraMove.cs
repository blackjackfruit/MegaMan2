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
				positionCamera(60.65f, -13.21f);
			}else if(cameraSwitch.Equals("Switch-02")){
				cameraY = -27.35f;
				positionCamera(60.65f, cameraY);
				allowFollow = true;
				
			}
			moveCamera = false;
		}
			
	}
	
	public void positionCamera(float x, float y){
		camera.transform.position = new Vector3(x, y, 6.42f);
	}
	
	void OnTriggerEnter(Collider c){
		
	}
	
	void OnCollsionEnter(Collision c){
		
	}
}
