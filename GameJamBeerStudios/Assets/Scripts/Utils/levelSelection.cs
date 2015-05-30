using UnityEngine;
using System.Collections;

public class levelSelection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SelectLevel(int value) {
		switch (value) {
		case 1:
			Application.LoadLevel ("nivel_1");
			break;
		case 2:
			Application.LoadLevel ("nivel_2");
			break;
		case 3:
			Application.LoadLevel ("nivel_3");
			break;
		case 4:
			Application.LoadLevel ("nivel_4");
			break;
		case 5:
			Application.LoadLevel ("nivel_5");
			break;
		case 6:
			Application.LoadLevel ("nivel_6");
			break;
		case 7:
			Application.LoadLevel ("nivel_boss");
			break;
		}
	}

	public void Exit(){
		Application.Quit();
	}
}
