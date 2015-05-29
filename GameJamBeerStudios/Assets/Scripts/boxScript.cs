using UnityEngine;
using System.Collections;

public class boxScript : MonoBehaviour {

	public int life = 1;
	public bool hasDrop = false;

	public enum dropItems{
		beer,
	};
	
	public dropItems drop = dropItems.beer;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == Tags.ball) {
			life --;
			if(life <= 0) {
				if(hasDrop){
					switch(drop){
					case dropItems.beer:
						//Instantiate
						break;
					}
				}

				Destroy (this);
			}
		}

	}
}
