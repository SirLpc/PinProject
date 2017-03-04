using UnityEngine;
using System.Collections;

public class YourGlobalSettings : MonoBehaviour
{

	[SerializeField]
	private bool _editMapMode;

	public bool EditMapMode{get{return _editMapMode; }}

	public static YourGlobalSettings Instance = null;

	private void Awake()
	{
		DontDestroyOnLoad (this.gameObject);
		Instance = this;
	}

	private void OnLevelWasLoaded(int level)
	{
		Debug.Log ("level loaded");
		GameObject.Find ("World1").transform.position = Vector3.zero;
		GameObject.Find ("6Paddles").transform.position = Vector3.zero;
		RenderSettings.ambientIntensity = 4.85f;
	}
}
