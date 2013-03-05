using UnityEngine;
using System.Collections;

public class CameraTrigger : MonoBehaviour {
	
	/*CameraTrigger are added to triggers called CameraStop and Swith-##(the pound signs are numbers)
	 * The CameraStop is the tigger responsible for stoping the camera from panning. An example 
	 * would be in the beginning of the level or before the stairs to go underground
	 * 
	 * The Switch-## are responsible for freezing megaman in place and playing an animation for moving
	 * the camera
	 */
	CameraMove mainCamera;
	
	void Start(){
		mainCamera = GameObject.Find("Main Camera").GetComponent<CameraMove>();
	}
	
	void OnTriggerEnter(Collider c){
		
		if(gameObject.name.Equals("CameraStop")){
			mainCamera.allowFollow = false;	
		}else if(gameObject.name.Equals("Switch-01")){
			mainCamera.cameraSwitch = "Switch-01";
			mainCamera.moveCamera = true;
		}else if(gameObject.name.Equals("Switch-02")){
			mainCamera.cameraSwitch = "Switch-02";
			mainCamera.moveCamera = true;	
		}
	}
	
	void OnTriggerExit(Collider c){
		if(gameObject.name.Equals("CameraStop"))
			mainCamera.allowFollow = true;
		else
			mainCamera.allowFollow = false;
	}
}
