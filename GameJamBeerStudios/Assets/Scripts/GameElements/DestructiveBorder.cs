using UnityEngine;
using System.Collections;

public class DestructiveBorder : MonoBehaviour {

	private GameManager gM;
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D other){
		gM = GameObject.FindGameObjectWithTag (Tags.gameManager).GetComponent<GameManager>();
		if (other.gameObject.tag == Tags.ball) {
			gM.RemoveBall(other.gameObject);
		}
		
	}
	
	void Update () {
	
	}
}
