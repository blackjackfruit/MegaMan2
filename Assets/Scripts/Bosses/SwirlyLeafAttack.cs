using UnityEngine;
using System.Collections;

public class SwirlyLeafAttack : MonoBehaviour {

	private int xPos = 0;
	private short direction = 0;
	private bool init = false;
	private float t;
	
	// Update is called once per frame
	void Update () {
		if(init){
			transform.position = new Vector3(xPos, -32f, 14);
			init = false;	
		}
		transform.Rotate(Vector3.forward, Time.deltaTime* 260);
		
		if(Time.time > t )
			Destroy(this.gameObject);
	}
	
	public void fireAttack(){
		transform.position -= new Vector3((-1)*direction*5f*Time.deltaTime,0f,0f);
	}
	public void setVariables(int x, short d){
		t = Time.time + 6;
		xPos = x;
		direction = d;
		init = true;
	}
}
