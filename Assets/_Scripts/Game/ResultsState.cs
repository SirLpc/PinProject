using UnityEngine;
using System.Collections;
namespace InaneGames {

	public class ResultsState : MonoBehaviour {

		private BrickoutGameScript m_gameScript;
		public UnityEngine.UI.Text timeText;
		public UnityEngine.UI.Text scoreText;
		private float m_gameOverTime;


		// Use this for initialization
		void Start () {
			m_gameScript = BrickoutGameScript.Instance;

			m_gameOverTime = Time.timeSinceLevelLoad;

		}
		// Update is called once per frame
		void Update () {
			if(m_gameScript)
			{
				if(timeText)
				{
					timeText.text = "Time:" + m_gameOverTime;
				}
				
				if(scoreText)
				{
					scoreText.text = "Score:" +  m_gameScript.getScore().ToString ();
				}
			}
			
		}

	}
}