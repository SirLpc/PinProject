using UnityEngine;
using System.Collections;
namespace InaneGames {

	public class OutOfBounds : MonoBehaviour {
		public Color gizmoColor = Color.red;
		public bool useEnter = true;
		void OnDrawGizmos()
		{
			Gizmos.color = gizmoColor;
			Gizmos.DrawCube (transform.position,transform.localRotation* transform.localScale);
		}
		
		void OnTriggerEnter (Collider col)
		{
			if(useEnter)
			{
				ballOut(col);
			}
		}
		
		void OnTriggerExit (Collider col)
		{
			if(useEnter==false)
			{
				ballOut(col);
			}
		}
		void ballOut(Collider col)
		{
			Ball ball = col.gameObject.GetComponent<Ball>();
			//a ball has gone out of bounds infrom the gamescript.
			if(ball)	
			{
				BrickoutGameScript.Instance.killABall (ball);
			}
		}
	}
}