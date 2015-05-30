using UnityEngine;
using System.Collections;

public class boxScript : MonoBehaviour {

	public int life = 1;
	public bool hasDrop = false;
	public bool breakable = true;

	public GameObject[] items;
	public int[] percentage;

	// Use this for initialization
	void Start () {
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (breakable) {
			if (collision.gameObject.tag == Tags.ball) {
				life--;
				if (life <= 0) {
					if (hasDrop) {
						float valueR = Random.Range(0, 100);

						if(valueR < percentage[0])
							Instantiate (items [0], transform.position, transform.rotation);
						else if(valueR < percentage[1])
							Instantiate (items [1], transform.position, transform.rotation);
						else if(valueR < percentage[2])
							Instantiate (items [2], transform.position, transform.rotation);
						else if(valueR < percentage[3])
							Instantiate (items [3], transform.position, transform.rotation);
						else if(valueR < percentage[4])
							Instantiate (items [4], transform.position, transform.rotation);
						else if(valueR < percentage[5])
							Instantiate (items [5], transform.position, transform.rotation);
						else if(valueR < percentage[6])
							Instantiate (items [6], transform.position, transform.rotation);
					}

					Destroy (gameObject);
				}
			}
		}
	}
}
