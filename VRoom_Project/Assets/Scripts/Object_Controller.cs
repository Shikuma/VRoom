using UnityEngine;
using System.Collections;

public class Object_Controller : MonoBehaviour {

    public bool selectable = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Select()
    {
        if(selectable)
        {
            Debug.Log("This object is selectable");
            //highlight object
            //display object name
            //hit space to play audio, boolean in update
        }
    }
}
