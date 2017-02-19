using UnityEngine;
using System.Collections;
public class Misc 
{
	public static float MOBILE_SPAWN_DELAY_TIME_SCALAR  = 2f;
	public static float MOBILE_ASTEROID_MOVE_SCALAR = 0.5f;
		
	
	public static string MAX_LEVEL_STR = "XXZ\tX_MAXX_LEVEL";
	public static string START_ROUND_STR = "XX_START_ROUND";
	public static string START_SPAWNER_STR = "XX_START_SPAWNER";
	
	public static string CONTROL_TYPE = "CONTROL_TYPE";
	
	public static float getControls()
	{
		return PlayerPrefs.GetFloat(CONTROL_TYPE,1);
	}
	public static bool getRegControls()
	{
		return PlayerPrefs.GetFloat(CONTROL_TYPE,1)==1;
	}
	public static void invertControls()
	{
		float invControls = getControls() * -1;
		Debug.Log ("controls" + invControls);
		PlayerPrefs.SetFloat(CONTROL_TYPE,invControls);
	}
	
	public static bool isMobile()
	{
		return Application.platform==RuntimePlatform.IPhonePlayer || 
			Application.platform==RuntimePlatform.Android;
	}
	public static bool setMaxLevel(int maxLevel)
	{
		bool newMaxLevel = false;
		int curMax = getMaxLevel();
		if(maxLevel > curMax)
		{
			PlayerPrefs.SetInt(MAX_LEVEL_STR,maxLevel);
			newMaxLevel = true;
		}
		return newMaxLevel;
	}

	//TODO Use true max level
	public static int getMaxLevel()
	{
		return Application.levelCount - Application.loadedLevel;

		return PlayerPrefs.GetInt(MAX_LEVEL_STR,1);
	}
	
	public static void setStartSpawnerIndex(int startRound)
	{
		PlayerPrefs.SetInt(START_SPAWNER_STR,startRound);
	}
	
	public static int getStartSpawnerIndex()
	{
		return PlayerPrefs.GetInt(START_SPAWNER_STR,0);
	}
	
	
	public static void setStartRound(int startRound)
	{
		PlayerPrefs.SetInt(START_ROUND_STR,startRound);
	}
	
	public static int getStartRound()
	{
		return PlayerPrefs.GetInt(START_ROUND_STR,1);
	}
	
	public static void setChildrenActive(GameObject go,
											bool active)
	{
		Transform t0 = go.transform;
		int t= t0.childCount;
		for(int i=0; i<t; i++)
		{
			if(t0.gameObject!=go)
			{
				t0.gameObject.SetActive(active);
			}
		}
	}
	public static void setActiveRecursively(GameObject go,
											bool active)
	{
		Transform t0 = go.transform;
		int t= t0.childCount;
		for(int i=0; i<t; i++)
		{
			t0.gameObject.SetActive(active);
		}
	}
}