using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour {
	public float initialDealy = 2.0f;  
	public float fadeInSpeed = 0.5f;  
	public float fadeOutSpeed = 0.5f;  
	private bool m_sceneStarting = true;  
	private bool m_sceneEnding = false;  
	private Image m_imageChapter;
	private Image m_imageVictory;
	private Image m_imageDefeat;

	private float m_timer = 0;

	private bool m_victory = false;

	void Start (){
		m_imageChapter = GetComponent<Image> ();
		m_imageVictory = GameObject.FindGameObjectWithTag (Tags.victory).GetComponent<Image> ();
		m_imageDefeat = GameObject.FindGameObjectWithTag (Tags.defeat).GetComponent<Image> ();

		m_imageVictory.enabled = false;
		m_imageDefeat.enabled = false;
	}
	
	void Update (){
		if(m_sceneStarting)
			StartScene();
		if(m_sceneEnding)
			EndScene();
	}

	void FadeToClear (){
		m_imageChapter.color = Color.Lerp (m_imageChapter.color, Color.clear, fadeInSpeed * Time.deltaTime);
	}

	void FadeToBlack (){
		m_imageChapter.color = Color.Lerp(m_imageChapter.color, Color.black, fadeOutSpeed * Time.deltaTime);
	}

	void StartScene (){
		m_timer += Time.deltaTime;

		if (m_timer > initialDealy) {
			FadeToClear ();
		
			if (m_imageChapter.color.a <= 0.05f) {
				m_imageChapter.color = Color.clear;
				m_imageChapter.enabled = false;
			
				m_sceneStarting = false;

				m_timer = 0;
			}
		}
	}
	
	public void End_Game (bool victory){
		m_sceneEnding = true;
		m_victory = victory;
	}
	
	void EndScene (){
		m_sceneStarting = false;
		
		FadeToBlack();
		
		if (m_imageChapter.color.a >= 0.95f) {
			if (m_victory){
				m_imageVictory.enabled = true;
				Debug.Log ("victoria");
			}
			else
				m_imageDefeat.enabled = true;
		}
	}
}
