using UnityEngine;
using System.Collections;

public class DoorAnimationUp : MonoBehaviour {
	
	void OnTriggerStay(Collider c){
		print(transform.position.y);
		if(c.gameObject.name.Equals("MegaMan")){
			if(transform.position.y < -22){
				transform.position += new Vector3(0,5f* Time.deltaTime,0);	
			}
		}
	}
	
}
