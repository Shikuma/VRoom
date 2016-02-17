using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {
	private bool shaderSet = true;
	private GameObject currObj = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update (){
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 10)){
			GameObject hitObj = hit.collider.gameObject;
            //print("Collided with " + hit.collider.gameObject.name);
            Debug.DrawLine(ray.origin, hit.point);
			if(hitObj.GetComponent<Object_Controller>() != null){
				print ("Calling select() for: " + hit.collider.gameObject.name);
				//print("Callind Deselect() for: " + 
				if (currObj != null)
					currObj.GetComponent<Object_Controller> ().Deselect ();
				hitObj.GetComponent<Object_Controller> ().Select();
				currObj = hitObj;
				
            }
        }

       // if (Input.GetAxis("Horizontal") > 0) gameObject.GetComponent<Rigidbody>().AddForce(transform.right, ForceMode.Impulse);
	}
}
