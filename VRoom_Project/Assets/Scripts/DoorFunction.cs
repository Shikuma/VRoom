using UnityEngine;
using System.Collections;

public class DoorFunction : MonoBehaviour {
	private float smooth = 2.0f, destAngle = 90.0f;
	private bool open;

	private Vector3 defaultRot, openRot;

	void Start () {
		defaultRot = transform.eulerAngles;
		/*
		print (defaultRot.z - destAngle);
		if (defaultRot.z - destAngle < 0) {
			destAngle = 360f - ((defaultRot.z - destAngle) * -1);
		} else {
			destAngle = defaultRot.z - destAngle;
		}
		*/
		openRot = new Vector3 (defaultRot.x, defaultRot.y, defaultRot.z - destAngle);
	}


	void Update () {
		if (open) {
			transform.eulerAngles = AngleLerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
		} else {
			transform.eulerAngles = AngleLerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
		}
	}

	public void useDoor(){
		open = !open;
	}

	private Vector3 AngleLerp(Vector3 StartAngle, Vector3 FinishAngle, float t)
	{        
		float xLerp = Mathf.LerpAngle(StartAngle.x, FinishAngle.x, t);
		float yLerp = Mathf.LerpAngle(StartAngle.y, FinishAngle.y, t);
		float zLerp = Mathf.LerpAngle(StartAngle.z, FinishAngle.z, t);
		Vector3 Lerped = new Vector3(xLerp, yLerp, zLerp);
		return Lerped;
	}
		


	/*public GameObject hinge;
	private bool doorStatus = false;
	public bool doorGo = false;
	private float closedRot;
	public float openRot;
	public float doorSpeed;
	// Use this for initialization
	void Start () {
		print (gameObject.transform.rotation.eulerAngles.z);
		closedRot = gameObject.transform.rotation.eulerAngles.z;
		openRot = closedRot - openRot;

	}
	
	// Update is called once per frame
	void Update () {
		if (doorGo) {
			if (transform.rotation.eulerAngles.z >= closedRot) {
				doorGo = !doorGo;
				transform.rotation =  Quaternion.Euler (0, 0, closedRot);
			} else if (transform.rotation.z <= openRot) {
				doorGo = !doorGo;
				transform.rotation = Quaternion.Euler (0, 0, openRot);
			}
			transform.RotateAround (hinge.transform.position, doorStatus ? -Vector3.up : Vector3.up, doorSpeed * Time.deltaTime);

		}
	}

	public void useDoor(){
		if (!doorGo) {
			
			doorStatus = !doorStatus;
			doorGo = true;
			if (!doorStatus){
				
				print ("OpenRot: " + openRot + " -- closedRot: " + closedRot);
			}
		}
	}*/
}
