using UnityEngine;
using System.Collections;

public class BossSelect : MonoBehaviour {
	
	
	public float[] row,column;
	
	private float zIndex = -1.64f;
	
	private int position = 4;
	// Use this for initialization
	void Start () {
		moveBox();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.UpArrow)){
			
			if(position > 2) {
				position -= 3;
				moveBox();
			}
		}else if(Input.GetKeyUp(KeyCode.DownArrow)){
			if(position < 7){
				position += 3;
				moveBox();
			}
			
		}else if(Input.GetKeyUp(KeyCode.RightArrow)){
			
			if(position < 8){
				position++;
				moveBox();
			}
			
		}else if(Input.GetKeyUp(KeyCode.LeftArrow)){
			
			if(position > 0){
				position--;
				moveBox();
			}
		}
		
		
		if(Input.GetKeyDown(KeyCode.S) && position == 5){
			Application.LoadLevel("WoodManLevel");	
		}
		
		
	}
	
	void moveBox(){
		audio.Play();
		if(position == 0){
			transform.position = new Vector3(row[0], column[0], zIndex);	
		}else if(position == 1){
			transform.position = new Vector3(row[1], column[0], zIndex);	
		}else if(position == 2){
			transform.position = new Vector3(row[2], column[0], zIndex);	
		}else if(position == 3){
			transform.position = new Vector3(row[0], column[1], zIndex);	
		}else if(position == 4){
			transform.position = new Vector3(row[1], column[1], zIndex);	
		}else if(position == 5){
			transform.position = new Vector3(row[2], column[1], zIndex);	
		}else if(position == 6){
			transform.position = new Vector3(row[0], column[2], zIndex);	
		}else if(position == 7){
			transform.position = new Vector3(row[1], column[2], zIndex);	
		}else if(position == 8){
			transform.position = new Vector3(row[2], column[2], zIndex);	
		}
	}
	
}
