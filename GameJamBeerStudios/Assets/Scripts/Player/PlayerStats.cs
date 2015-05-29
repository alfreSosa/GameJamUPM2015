using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {



	private GameManager gameManager;
	void Start () {
		GameObject gManager = GameObject.FindGameObjectWithTag (Tags.gameManager);
		gameManager = gManager.GetComponent<GameManager>();

	}
	
	// Update is called once per frame
	void Update () {

	}


}
