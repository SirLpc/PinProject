using UnityEngine;
using System.Collections;

public class RotateWithOther : MonoBehaviour {


	[SerializeField]
	private Transform _targetTr;

	private Transform _tr;

	void Awake()
	{
		_tr = transform;
	}

	void Update ()
	{
		var taru = _targetTr.localEulerAngles;
		_tr.localEulerAngles = new Vector3(0, 0, taru.y * -1);
	}
}
