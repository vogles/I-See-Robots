using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public bool start = false;
	public bool opti = false;
	public bool quit = false;
	public bool back = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnClick () {

		if (start) {
			Application.LoadLevel("02_Level");
		}

		if (opti) {
			Application.LoadLevel("00_Credits");
		}

		if (quit) {
			Application.Quit();
		}

		if (back) {
			Application.LoadLevel("01_Title");

	}
}
}