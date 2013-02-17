using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {
	
	public float[] CursorPos1;
	public float[] CursorPos2;
	public string nextScene;
	public AudioClip audioClip;
	
	private float time = 0;
	private int position = 0;
	private bool showCursor;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.S) && (position == 0))
			Application.LoadLevel(nextScene);
			
		
		if(Input.GetKeyUp(KeyCode.UpArrow)){
			print("up " + position);
			if(position == 1){
				position--;	
				audio.Play();
			}
		}else if(Input.GetKeyUp(KeyCode.DownArrow)){
			print("down " + position );
			
			if(position == 0){
				position++;
				audio.Play();
			}
			
		}
		
		if((Time.time - time) > .4f){
			time = Time.time;
			if(showCursor){
				renderer.enabled = true;
				showCursor = false;
			}else {
				renderer.enabled = false;
				showCursor = true;
			}
			
		}
		
		if(position == 0){
			transform.position = new Vector3(CursorPos1[0], CursorPos1[1], CursorPos1[2]);
		}else if(position == 1){
			transform.position = new Vector3(CursorPos2[0], CursorPos2[1], CursorPos2[2]);	
		}
	}
}
