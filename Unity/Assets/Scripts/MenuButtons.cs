using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public bool start = false;
	public bool opti = false;
	public bool quit = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnClick () {
		//counter++;
		//print ("Clicked " + counter.ToString () + " times.");

		if (start) {
			Application.LoadLevel("02_Training");
		}

		if (opti) {
			Application.LoadLevel("00_Options");
		}

		if (quit) {
			Application.Quit();
		}

	}
}
