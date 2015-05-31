using UnityEngine;
using System.Collections;

public class levelSelection : MonoBehaviour {

	public void SelectLevel(int value) {
		switch (value) {
		case 0:
			Application.LoadLevel ("creditos");
			break;
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
			Application.LoadLevel ("nivel_07");
			break;
		case 8:
			Application.LoadLevel ("nivel_08");
			break;
		case 9:
			Application.LoadLevel ("nivel_09");
			break;
		case 10:
			Application.LoadLevel ("nivel_10");
			break;
		case 11:
			Application.LoadLevel ("nivel_11");
			break;
		case 12:
			Application.LoadLevel ("nivel_12");
			break;
		case 13:
			Application.LoadLevel ("nivel_13");
			break;
		case 14:
			Application.LoadLevel ("nivel_14");
			break;
		case 15:
			Application.LoadLevel ("nivel_15");
			break;
		case 16:
			Application.LoadLevel ("nivel_16");
			break;
		case 17:
			Application.LoadLevel ("nivel_17");
			break;
		case 18:
			Application.LoadLevel ("nivel_18");
			break;
		case 19:
			Application.LoadLevel ("nivel_19");
			break;
		case 20:
			Application.LoadLevel ("nivel_boss");
			break;
		}
	}

	public void Exit(){
		Application.Quit();
	}
}
