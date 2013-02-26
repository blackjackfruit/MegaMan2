using UnityEngine;
using System.Collections;

public class SwirlyLeafAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward, Time.deltaTime* 260);
	}
	
	public void fireAttack(){
		//print ("bo");
		transform.position -= new Vector3(.2f, 0,0);
	}
}
