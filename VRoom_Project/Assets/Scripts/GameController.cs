using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public bool paused;
	public GameObject pauseScreen, HUD;
	// Use this for initialization
	void Start () {
		pauseScreen.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pause(){
		paused = !paused;
		HUD.SetActive (!paused);
		pauseScreen.SetActive (paused);
		Time.timeScale = paused ? 0 : 1;
	}
}
