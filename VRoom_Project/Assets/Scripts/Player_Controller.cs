using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class Player_Controller : MonoBehaviour {
	private bool shaderSet = true;
	private GameObject currObj = null;
    public GameObject namePanel, gameController;
	GameController GC;
	// Use this for initialization
	void Start () {
        namePanel.SetActive(false);
		GC = gameController.GetComponent<GameController> ();
	}

	// Update is called once per frame
	void Update (){
		//Pausing
		if (Input.GetKeyDown (KeyCode.Escape)) 
			GC.pause ();



        Quaternion HMDRotation = InputTracking.GetLocalRotation(VRNode.CenterEye);
        Vector3 playerRotation = HMDRotation * transform.forward;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 20f)){
			GameObject hitObj = hit.collider.gameObject;
            
			//print("Collided with " + hit.collider.gameObject.name);
            Debug.DrawLine(ray.origin, hit.point, Color.cyan);
            
			//Turn off name display if object is not selectable
            if (hitObj.GetComponent<Object_Controller>() == null) namePanel.SetActive(false);

            if (currObj != null && currObj.GetComponent<Object_Controller>() != null)
                currObj.GetComponent<Object_Controller>().Deselect();

            if (hitObj.GetComponent<Object_Controller>() != null){
                //De-Select
				
                //Display name if off
                if (!namePanel.activeSelf) namePanel.SetActive(true);
                //Select object
				hitObj.GetComponent<Object_Controller> ().Select();
                //Set object as curr object
				currObj = hitObj;
				
            }

			//Door action
			if (hitObj.tag == "Door" && hitObj.GetComponentInParent<DoorFunction>() != null ) {
				if (Input.GetKeyDown (KeyCode.F)) {
					hitObj.GetComponentInParent<DoorFunction> ().useDoor ();
				}
			}
        }

       // if (Input.GetAxis("Horizontal") > 0) gameObject.GetComponent<Rigidbody>().AddForce(transform.right, ForceMode.Impulse);
	}
}
