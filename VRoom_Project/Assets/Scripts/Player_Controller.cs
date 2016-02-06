using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 10))
        {
            print("Collided with" + hit.collider.gameObject.name);
            Debug.DrawLine(ray.origin, hit.point);
            if(hit.collider.gameObject.GetComponent<Object_Controller>() != null)
            {
                hit.collider.gameObject.GetComponent<Object_Controller>().Select();
            }
        }
	}
}
