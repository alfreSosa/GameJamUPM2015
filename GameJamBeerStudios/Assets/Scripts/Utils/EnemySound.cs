using UnityEngine;
using System.Collections;

public class EnemySound : MonoBehaviour {

	//public AudioSource sound;
	public float time = 2.0f;
	private float elapsed = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (elapsed);
		elapsed += Time.deltaTime;
		if (elapsed >= time) {
			Destroy(gameObject);
		}
		/*if (!sound.isPlaying)
			sound.Play ();*/
	}
}
