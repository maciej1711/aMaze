using UnityEngine;
using System.Collections;

public class tvTrigg : MonoBehaviour {
	//GUI.skin = customSkin;
	GameObject TVtrig;

	public GUISkin customSkin;
	string EditableString="";
	string text;
	bool Entered=false,trigEnter=false;

	void OnTriggerEnter(Collider oth){
		if (oth.name == "First Person Controller") 
		trigEnter=true;
	}

	void OnTriggerStay(Collider other) { // Look at here
		if (other.name == "First Person Controller") {

						if (Input.GetKeyDown (KeyCode.E)) {
				Entered=true;

						}
				}

	}
		void OnGUI(){
		GUI.skin = customSkin;
		if(Entered==true&&trigEnter==true){
			GUI.Label (new Rect (Screen.width / 3, Screen.height / 2-100, 400, 80), "Type encrypted words here:");
			EditableString=GUI.TextField(new Rect(Screen.width / 3, Screen.height / 2, 400, 40), EditableString, 24);

			}
			if(EditableString.Length==24){
					text=crys.Decrypt (EditableString);
		if (text != null) {
						GUI.Label (new Rect (Screen.width / 3, Screen.height / 3 + 50, 400, 40), "Your word is: " + text);
			}
		
		}	
	}

	void OnTriggerExit(Collider other){
		if (other.name == "First Person Controller")
						trigEnter = false;
		}
	void Start () {
	
	}

	void Update () {
	
	}
}
