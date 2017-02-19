using UnityEngine;
using System.Collections;
namespace InaneGames {

	public class Rotator : MonoBehaviour {

		public float rotationSpeed = 55;
		public Vector3 upVec = Vector3.up;
		
		void Update () {
			transform.Rotate( upVec * Time.deltaTime * rotationSpeed );//* StackRotator.SPEED_SCALAR );
		}
	}
}