using UnityEngine;
using System.Collections;

public class FallingLeafAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void fireAttack(){
		transform.position -= new Vector3(0,.15f,0);	
	}
}
