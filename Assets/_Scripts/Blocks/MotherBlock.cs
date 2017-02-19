using UnityEngine;
using System.Collections;


namespace InaneGames {

	public class MotherBlock : Block {
		//the block spawn time
		public float blockSpawnTime = 5;


		private float m_blockSpawnTime=0;

		//the inital number of blocks
		public int initalNomBlocks = 4;

		//the max number of blocks
		public int maxBlocks = 6;

		public override void Start()
		{
			base.Start();
			for(int i=0; i<initalNomBlocks; i++)
			{
				spawnBlocks();
			}
		}

		void spawnBlocks()
		
		{
			Block[] blocks = gameObject.GetComponentsInChildren<Block>();
			if(blocks.Length<maxBlocks)
			{
				
				m_blockSpawnTime=blockSpawnTime;
				Vector3 offset = Random.onUnitSphere * childRadius;
				offset.y=0;
				GameObject go = (GameObject)Instantiate(childObject,transform.position + offset,Quaternion.identity);
				if(go)
				{
					go.transform.parent = transform;
				}
			}
		}
		void Update () {
			if(m_blockSpawnTime<0)
			{
				spawnBlocks();

			}
			m_blockSpawnTime-=Time.deltaTime;
		}
	}
}