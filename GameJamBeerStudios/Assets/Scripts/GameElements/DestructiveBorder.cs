using UnityEngine;
using System.Collections;

public class DestructiveBorder : MonoBehaviour {

	private GameManager gM;
	void Start () {
		gM = GameObject.FindGameObjectWithTag (Tags.gameManager).GetComponent<GameManager>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == Tags.ball) {
			gM.RemoveBall(other.gameObject);
		}
		
	}
	
	void Update () {
	
	}
}
