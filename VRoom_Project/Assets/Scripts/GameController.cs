using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public bool paused;
	public GameObject pauseScreen, HUD;
	private GameObject player;
	OVRPlayerController playerController;
	// Use this for initialization
	void Start () {
		pauseScreen.SetActive (false);
		player = GameObject.FindWithTag ("Player");
		playerController = player.GetComponent<OVRPlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pause(){
		paused = !paused;
		HUD.SetActive (!paused);
		pauseScreen.SetActive (paused);
		if (paused) {
			playerController.JumpForce = 0f;
			playerController.Acceleration = 0f;
		} else {
			playerController.JumpForce = 0.3f;
			playerController.Acceleration = 0.1f;
		}
	}
}
