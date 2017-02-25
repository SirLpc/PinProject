using UnityEngine;
using System.Collections;

namespace InaneGames {

	public class Paddle : MonoBehaviour {
		//the move speed of the paddle
		public	 float moveSpeed = -	500f;

		//the inital time
		public float initalTime = 0f;

		//the current time
		private float m_time = 0f;

		//the control scalar
		private float m_controlScalar = 1;

		//the circle radius
		public float circleRadius = 20f;


		//the currnet stun time
		private float m_stunTime;

		//the time the paddle should be stunned for.
		public float stunTime = 1;


//		public  void Start()
//		{
//			m_controlScalar = Misc.getControls();
//			m_time = initalTime * Mathf.Deg2Rad;
//			
//			setCircleAngle(m_time);
//		}
//
//		void OnEnable()
//		{
//			GameManager.onBallOutOfBounds += moveToOrigin;
//		}
//		void OnDisable()
//		{
//			GameManager.onBallOutOfBounds -= moveToOrigin;			
//		}
//		public void stunPaddle()
//		{
//			m_stunTime = stunTime;
//		}
//
//
//		
//		void moveToOrigin()
//		{
//			m_time = initalTime * Mathf.Deg2Rad;
//			
//			setCircleAngle(m_time);
//		}
//
//		public void Update()
//		{
//			#if !UNITY_EDITOR
//			m_stunTime -= Time.deltaTime;
//			
//			if(m_stunTime<0)
//			{
//				circleUpdate();
//			}
//			#endif
//		}
//
//		void circleUpdate()
//		{
//			float r0 = Input.GetAxis("Horizontal") * m_controlScalar;
//
//			
//			if(r0!=0f)
//			{
//				GetComponent<Rigidbody>().velocity = transform.right.normalized * moveSpeed * r0;
//			}else{	
//				GetComponent<Rigidbody>().velocity = Vector3.zero;
//			}
//
//			constrainCirc();
//			//lookAtCenter();
//		}
//		void setCircleAngle(float angle0)
//		{
//			if(transform)
//			{
//				Vector3 vec = transform.position;
//				vec.x = Mathf.Sin(angle0) * circleRadius;
//				vec.z = Mathf.Cos(angle0) * circleRadius;
//				
//				transform.position = vec;
//
//				lookAtCenter ();
//			}
//		}
//		void constrainCirc()
//		{
//			float angle0 = Mathf.Atan2(transform.position.x,transform.position.z);
//			setCircleAngle(angle0);
//		}
//		
//		void lookAtCenter()
//		{	
//			Vector3 vec = Vector3.zero;
//			vec.y= transform.position.y;
//			transform.LookAt(vec);
//		}



	}
}
