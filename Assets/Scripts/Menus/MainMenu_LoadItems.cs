using UnityEngine;
using System.Collections;

public class MainMenu_LoadItems : MonoBehaviour {
	
	public AudioClip introClip, mainMenuClip;
	public Transform title, cursor, items;
	
	private bool mainMenuClipBool;
	// Use this for initialization
	void Start () {
			title.renderer.enabled = false;
			items.renderer.enabled	= false;
			audio.clip = introClip;
			audio.Play();
		mainMenuClipBool = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(animation.isPlaying == false){
			title.renderer.enabled = true;
			items.renderer.enabled	= true;
			
			if(mainMenuClipBool){
				audio.clip = mainMenuClip;
				audio.Play();
				mainMenuClipBool = false;
			}
			
		}
	}
}
