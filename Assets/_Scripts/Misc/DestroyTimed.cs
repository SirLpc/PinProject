using UnityEngine;
using System.Collections;
namespace InaneGames {

	public class DestroyTimed : MonoBehaviour
	{
		public float ttl=1;


		private void OnEnable () 
		{
			DelayedRecycle ();
		}
		
		private void DelayedRecycle()
		{
			PoolSpawner.Instance.Despawn (transform, ttl);
		}
	}
}