using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InitialTransition : MonoBehaviour {

	public float[] times;
	private Image[] m_images;

	private float m_currentTime = 0.0f;

	// Use this for initialization
	void Start () {
		m_images = GetComponentsInChildren<Image> ();
		int size = m_images.Length;
		for (int i = 0; i < size; i++)
			m_images[i].enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (times.Length == m_images.Length) {
			m_currentTime += Time.deltaTime;

			if(m_currentTime <= times[0])
				m_images[0].enabled = true;
			else if(m_currentTime <= times[1])
				m_images[1].enabled = true;
			else if(m_currentTime <= times[2])
				m_images[2].enabled = true;
			else if(m_currentTime <= times[3])
				m_images[3].enabled = true;
			else if(m_currentTime <= times[4])
				m_images[4].enabled = true;
			else if(m_currentTime <= times[5])
				m_images[5].enabled = true;
			else 
				Application.LoadLevel ("SelectGames");
		}
		if (Input.GetAxis ("Throw") != 0.0f)
			Application.LoadLevel ("SelectGames");
	}
}
