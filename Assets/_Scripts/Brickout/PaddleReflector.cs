using UnityEngine;
using System.Collections;

namespace InaneGames {

	public class PaddleReflector : MonoBehaviour {
		private Paddle m_paddle;
		private AudioSource m_audioSource;
		void Start()
		{
			m_paddle = gameObject.transform.GetComponentInParent<Paddle>();
			m_audioSource = gameObject.GetComponent<AudioSource>();
		}

		void OnTriggerEnter(Collider col)
		{
			Ball ball = col.transform.GetComponent<Ball>();
			if(ball) 
			{
				if(m_audioSource)
				{
					m_audioSource.Play();
				}
				GameManager.ballHitPaddle(m_paddle , ball);
			}
		}
	}
}