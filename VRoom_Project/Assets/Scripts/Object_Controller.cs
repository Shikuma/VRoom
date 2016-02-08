using UnityEngine;
using System.Collections;

public class Object_Controller : MonoBehaviour {
	public Shader highlightShader;
    public bool selectable = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Select(){
        if(selectable){
            Debug.Log("This object is selectable");
            //highlight object
			if (GetComponent<Renderer> () != null) {
				GetComponent<Renderer> ().material.shader = highlightShader;
				print ("Setting shader for parent");
			} else
				print ("Parent renderer is null");
			if(transform.childCount > 0){
				print (gameObject.name);
				foreach(Transform t in transform){
					print (t.name);

					t.GetComponent<Renderer>().material.shader = highlightShader;
				}
			}
		
			//GetComponent<Renderer>().material.shader = highlightShader;
            //display object name
            //hit space to play audio, boolean in update
        }
    }


}
