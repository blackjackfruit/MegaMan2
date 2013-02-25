/*
  <one line to give the program's name and a brief idea of what it does.>
    Copyright (C) <2013>  <Mr.Krow@yellokrow.com>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
    
 */

using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {
	
	public float[] CursorPos1;
	public float[] CursorPos2;
	public string nextScene;
	public AudioClip audioClip;
	public Camera camera_v;
	
	private float time = 0;
	private int position = 0;
	private bool showCursor;
	
	
	// Use this for initialization
	void Start () {
		renderer.enabled = false;
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
		
		if(camera_v.animation.isPlaying == false){
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
		}
		
		if(position == 0){
			transform.position = new Vector3(CursorPos1[0], CursorPos1[1], CursorPos1[2]);
		}else if(position == 1){
			transform.position = new Vector3(CursorPos2[0], CursorPos2[1], CursorPos2[2]);	
		}
	}
	
}

