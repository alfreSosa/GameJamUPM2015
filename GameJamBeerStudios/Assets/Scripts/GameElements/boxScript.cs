using UnityEngine;
using System.Collections;

public class boxScript : MonoBehaviour {

	public int life = 1;
	public bool hasDrop = false;

	public enum dropItems{
		beer = 0,
	};
	
	public dropItems drop = dropItems.beer;

	public GameObject[] items;

	// Use this for initialization
	void Start () {
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == Tags.player) {
			life--;
			if(life <= 0) {
				if(hasDrop){
					Debug.Log ("creando");
					Instantiate (items[(int)drop], transform.position, transform.rotation);
				}

				Destroy (gameObject);
			}
		}

	}
}
