using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class PaddleRotator : MonoBehaviour
{

	[SerializeField]
	private Transform _targetTr;

	void OnEnable () 
	{
		EasyTouch.On_Swipe += OnSwipe;
		Debug.Log ("roteat");
	}

	void OnDisable () 
	{
		EasyTouch.On_Swipe -= OnSwipe;
		Debug.Log ("roteat");
	}

	void OnDistroy () 
	{
		EasyTouch.On_Swipe -= OnSwipe;
		Debug.Log ("roteat");
	}
	
	
	void OnSwipe (Gesture gesture)
	{
		Debug.Log ("roteat");
		_targetTr.Rotate (new Vector3 (gesture.deltaPosition.x, 0, gesture.deltaPosition.y));
	}
}
