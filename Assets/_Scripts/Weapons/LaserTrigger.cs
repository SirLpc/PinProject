using UnityEngine;
using System.Collections;
namespace InaneGames {

	public class LaserTrigger : MonoBehaviour {
		public Laser laser;
		void OnTriggerStay (Collider col) 
		{
			Block b = col.gameObject.GetComponent<Block>();
			if(b && laser)
			{
				laser.damage( b );			
			}
		}
		

	}
}