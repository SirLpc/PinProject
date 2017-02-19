using UnityEngine;
using System.Collections;
namespace InaneGames {

	public class Laser : MonoBehaviour {
		public GameObject laserChild;
		private float laserDamage = 150f;
		public float laserTime = 1f;
		void Awake()
		{
			setLaserChildActive(false);
		}
		public void damage(Block block)
		{
			if(block)
			{

				block.onHit(block.transform.position,laserDamage * Time.deltaTime,false);
			}
		}
		void OnEnable()
		{
			GameManager.onLaserStart += laserOn;
			GameManager.onLaserEnd += laserEnd;
			GameManager.onBallOutOfBounds += laserEnd;
			GameManager.onNewStack += onNewStack;

		}
		void OnDisable()
		{
			GameManager.onLaserStart -= laserOn;
			GameManager.onLaserEnd -= laserEnd;
			GameManager.onBallOutOfBounds -= laserEnd;
			GameManager.onNewStack -= onNewStack;
		}
		void onNewStack(int stackIndex)
		{
			laserEnd();
		}
		void laserOn(	)
		{
			setLaserChildActive( true );
		}
		
		void laserEnd()
		{
			setLaserChildActive( false );
		}
		void setLaserChildActive(bool active)
		{
			if(laserChild)
			{
				laserChild.SetActive( active );
			}
			
		}
	}
}
