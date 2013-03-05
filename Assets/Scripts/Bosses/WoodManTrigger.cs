using UnityEngine;
using System.Collections;

public class WoodManTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider c){
			print (c.name);
			print("hit");
	}
}
