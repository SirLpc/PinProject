using UnityEngine;
using System.Collections;
namespace InaneGames {

	public class PlayState : MonoBehaviour {
		private BrickoutGameScript m_gameScript;
		public UnityEngine.UI.Text m_livesText;
		public UnityEngine.UI.Text m_scoreText;

		// Use this for initialization
		void Start () {
			m_gameScript = BrickoutGameScript.Instance;

		}
		
		// Update is called once per frame
		void Update () {
			if(m_gameScript)
			{
				if(m_livesText)
				{
					m_livesText.text = m_gameScript.getNomLives().ToString();
				}

				if(m_scoreText)
				{
					m_scoreText.text = m_gameScript.getScore().ToString ();
				}
			}

		}
	}
}