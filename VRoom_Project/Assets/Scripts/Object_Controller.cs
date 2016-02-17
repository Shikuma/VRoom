using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Object_Controller : MonoBehaviour {
	public Shader highlightShader;
    public bool selectable = false;
	public GameObject[] objectGroup;
	public string objName = "Object Name";
	public Text name;
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
				for (int i = 0; i < objectGroup.Length; i++) {
					objectGroup [i].GetComponent<Renderer> ().material.shader = highlightShader;
				}

			} else Debug.Log ("Parent renderer is null");

			name.text = objName;

			//GetComponent<Renderer>().material.shader = highlightShader;
            //display object name
            //hit space to play audio, boolean in update
        }
    }

	public void Deselect(){
		GetComponent<Renderer> ().material.shader = Shader.Find ("Standard");
		for (int i = 0; i < objectGroup.Length; i++) {
			objectGroup [i].GetComponent<Renderer> ().material.shader = Shader.Find ("Standard");
		}
		name.text = "";
	}


}
