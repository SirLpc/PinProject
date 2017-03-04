using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using InaneGames;

public class ChapterDataReader : MonoBehaviour
{

	private int cid;



	void Start()
	{
		cid = SceneManager.GetActiveScene().buildIndex;

		Block[] bs = GetComponentsInChildren<Block> ();
		foreach (var item in bs)
		{
			Destroy (item.gameObject);
		}

		ReadData ();
	}

	void OnGUI ()
	{
		if (GUILayout.Button ("Read Data"))
		{
			ReadData ();
		}
	}



	private void ReadData()
	{
		//int myInt = ES2.Load<int>("myFile.bytes?tag=myInt&savelocation=resources");
		var dd = ES2.Load<ChapterModel> ("ChapterData.bytes?tag=" + cid + "&savelocation=resources");
		//Debug.Log (dd.ChapterID);
		for (int i = 0; i < dd.EnemyLocPositin.Count; i++)
		{
			var tr = PoolSpawner.Instance.SpawnEnemy ((EnemyType)dd.EnemyType [i]);
			//tr.GetComponent<Block>().
			tr.SetParent (this.transform);
			tr.localPosition = dd.EnemyLocPositin [i];
			//tr.localEulerAngles = new Vector3 (0f, 180f, 180f);
			var tar = transform.position;
			tar.x += Random.Range (-70f, 70f);
			tar.z += Random.Range (-70f, 70f);
			tr.LookAt(tar);
			tr.localScale = Vector3.one;
			tr.Rotate (new Vector3(180f, 0f, 0f));
			//tr.localEulerAngles = dd.EnemyLocRotationEuler [i];
			//tr.localScale = dd.EnemyLocScale [i];
			tr.name = "bbb" + i;
			//Debug.Log (tr.localPosition + "        " + i);
		}

	}
}
