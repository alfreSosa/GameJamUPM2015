using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour {
	public float initialDealy = 2f;  
	public float fadeInSpeed = 0.5f;  
	public float fadeOutSpeed = 0.5f; 
	private bool m_sceneStarting = true;  
	private bool m_sceneEnding = false;  
	private Image m_image;

	private float m_timer = 0;

	void Start (){
		m_image = GetComponent<Image> ();
	}
	
	void Update (){
		if(m_sceneStarting)
			StartScene();
		if(m_sceneEnding)
			EndScene();
	}
	
	
	void FadeToClear (){
		m_image.color = Color.Lerp (m_image.color, Color.clear, fadeInSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack (){
		m_image.color = Color.Lerp(m_image.color, Color.black, fadeOutSpeed * Time.deltaTime);
	}
	
	void StartScene (){
		m_timer += Time.deltaTime;

		if (m_timer > initialDealy) {
			FadeToClear ();
		
			if (m_image.color.a <= 0.05f) {
				m_image.color = Color.clear;
				m_image.enabled = false;
			
				m_sceneStarting = false;

				m_timer = 0;
			}
		}
	}
	
	public void End (){
		m_sceneEnding = true;
	}
	
	void EndScene (){
		m_sceneStarting = false;
		m_image.enabled = true;
		
		FadeToBlack();
		
		if (m_image.color.a >= 0.95f) {
			//hacer cosas de fin
		}
	}
}
