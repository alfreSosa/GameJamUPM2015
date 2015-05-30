using UnityEngine;
using System.Collections;

public class levelSelection : MonoBehaviour {

	public void SelectLevel(int value) {
		switch (value) {
		case 1:
			Application.LoadLevel ("nivel_01");
			break;
		case 2:
			Application.LoadLevel ("nivel_02");
			break;
		case 3:
			Application.LoadLevel ("nivel_03");
			break;
		case 4:
			Application.LoadLevel ("nivel_04");
			break;
		case 5:
			Application.LoadLevel ("nivel_05");
			break;
		case 6:
			Application.LoadLevel ("nivel_06");
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
