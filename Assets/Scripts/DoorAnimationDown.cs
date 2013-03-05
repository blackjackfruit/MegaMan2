using UnityEngine;
using System.Collections;

public class DoorAnimationDown : MonoBehaviour {
	
	public Transform door;
	
	void OnTriggerStay(){
		if(door.transform.position.y > -27){
			door.position -= new Vector3(0,5f*Time.deltaTime,0);	
		}else {
			if(gameObject.name.Equals("TriggerDown02")){
				GameObject.Find("WoodMan").GetComponent<WoodMan>().enabled = true;
			}
			Destroy(this.gameObject);
		}
	}
}
