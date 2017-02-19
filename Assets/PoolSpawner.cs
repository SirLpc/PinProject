using UnityEngine;
using System.Collections;
using PathologicalGames;

public class PoolSpawner : MonoBehaviour 
{
	public static PoolSpawner Instance = null;

	private SpawnPool spawnPool;

	private void Awake()
	{
		Instance = this;
		Object.DontDestroyOnLoad(this.gameObject);

		spawnPool = GetComponent<SpawnPool> ();
	}

	public Transform SpawnExplosion(Vector3 position, Quaternion rotation)
	{
		return spawnPool.Spawn ("ExplosionMobile", position, rotation);
	}

	public void Despawn(Transform target, float delay)
	{
		spawnPool.Despawn (target, delay);
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.P))
			SpawnExplosion (Vector3.zero, Quaternion.identity);
	}

}
