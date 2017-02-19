using UnityEngine;
using System.Collections;

namespace InaneGames {

	public class Magnet : MonoBehaviour {

		public float magnetRange = 20;
		// Update is called once per frame
		void Update () {
			Ball ball =  (Ball)GameObject.FindObjectOfType(typeof(Ball));
			if(ball)
			{
				Vector3 vec = transform.position - ball.transform.position;
				if(vec.magnitude<30)
				{
					ball.GetComponent<Rigidbody>().velocity = vec.normalized * ball.ballSpeed;
				//	ball.transform.LookAt( transform.position);
				}
			}
		}
	}
}