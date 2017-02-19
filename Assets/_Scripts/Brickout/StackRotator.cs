using UnityEngine;
using System.Collections;
namespace InaneGames {

	public class StackRotator	 : MonoBehaviour {
		public float thrust;
		public Rigidbody rb;
		public static float SPEED_SCALAR = 1f;
		private float m_stunnedTime=0;
		void Start() {
			rb = GetComponent<Rigidbody>();
		}
		public void onHitBlock()
		{
			m_stunnedTime=.5f;
		}
		#if UNITY_EDITOR
		public void Update()
		{
			if(m_stunnedTime<0)
			{
				float h = Input.GetAxis("Horizontal") * Time.deltaTime;
				rb.angularVelocity = new Vector3(0,thrust*h,0);
				SPEED_SCALAR=1;
			}else{
				rb.angularVelocity=Vector3.zero;
				SPEED_SCALAR=0;
			}
			m_stunnedTime-=Time.deltaTime;
		}
		#endif

	}
}