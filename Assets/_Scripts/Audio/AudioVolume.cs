using UnityEngine;
using System.Collections;

public class AudioVolume : MonoBehaviour {

	public float volScalar = 1f;
	void Start () {
		if(GetComponent<AudioSource>())
		{
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("AudioVolume",1) * volScalar;
		}
	}
	
	void Update () {
		if(GetComponent<AudioSource>())
		{
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("AudioVolume",1) * volScalar;
			
		}
	}
}
