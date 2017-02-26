using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using InaneGames;


public class ChapterDataSaver : MonoBehaviour
{

	private int cid;
	private string cpath;

	void Awake()
	{
		cid = SceneManager.GetActiveScene().buildIndex;

		cpath = Application.dataPath+"/Resources/ChapterData.bytes?tag=" + cid;
	}

	void OnGUI ()
	{
		if (GUILayout.Button ("Save Data"))
		{
			SaveData ();
		}
		if (GUILayout.Button ("Read Data"))
		{
			ReadData ();
		}
	}

	private void SaveData()
	{
		ChapterModel cm = new ChapterModel ();

		cm.ChapterID = cid = SceneManager.GetActiveScene().buildIndex;

		Block[] bs = GetComponentsInChildren<Block> ();
		cm.EnemyLocPositin = new System.Collections.Generic.List<Vector3> ();
		cm.EnemyLocRotationEuler = new System.Collections.Generic.List<Vector3> ();
		cm.EnemyLocScale = new System.Collections.Generic.List<Vector3> ();
		cm.EnemyType = new System.Collections.Generic.List<int> ();
		foreach (var item in bs)
		{
			cm.EnemyLocPositin.Add (item.transform.localPosition);
			cm.EnemyLocRotationEuler.Add (item.transform.localEulerAngles);
			cm.EnemyLocScale.Add (item.transform.localScale);
			cm.EnemyType.Add ((int)item.Type);
		}

		Debug.Log ("save success" + cpath);
		ES2.Save (cm, cpath);

	}

	private void ReadData()
	{
		var dd = ES2.Load<ChapterModel> (cpath);
		Debug.Log (dd.ChapterID);
		foreach (var item in dd.EnemyLocPositin) {
			Debug.Log (item);
		}
	}
}
