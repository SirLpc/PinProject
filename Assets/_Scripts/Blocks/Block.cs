using UnityEngine;
using System.Collections;

namespace InaneGames {

	public class Block : MonoBehaviour 
	{
		//the score gotten for each block destroyed, will be multipled by the number of hits.
		public int bounty = 5;
		
		//the number of hits the block has before its destroyed
		public float nomHits = 3;

		//the maximum number of hits the block has
		private float m_nomHits;

		//the number of children
		public int nomChildren = 3;

		//a child object
		public GameObject childObject;

		//the child radius
		public float childRadius = 10;

		//a gameobject that will be created when the block is hit
		//public GameObject objectOnHit;

		//is this object a power core.
		public bool isPowerCore = false;

		//the regular scalar
		public float regularScalar = 1f;
		//the laser scalar
		public float laserScalar = 1f;

		//has the AOE happeend
		private bool m_doneAOE = false;

		//the aoe damage
		public float aoeDamage = 1;
		


		//has the block already been destroyed
		protected bool m_destroyed = false;

		//the aoe radius
		public float aoeRadius = 30;

		/// <summary>
		/// The damage per hit
		/// </summary>
		public float damage = 5;

		//the gamescript
		protected BrickoutGameScript m_gameScript;

		//the object on death
		public GameObject objectOnDeath;

		//the invincible.
		protected bool m_invincible = false;

		
		public virtual void Start()
		{
			//set the number hits
			if(isPowerCore)
			{
				laserScalar=0;
				gameObject.AddComponent<Magnet>();
			}

			m_nomHits = nomHits;
			m_gameScript = BrickoutGameScript.Instance;
			if(m_gameScript && isPowerCore)
			{
				//infroms the gamescript that a block is created
				m_gameScript.addBlock();
			}
		}
		public void setInvincible(bool inv)
		{
			m_invincible=inv;
		}
		public bool getInvincible()
		{
			return m_invincible;
		}


		//something has hit the block
		public void onHit(Vector3 onHit,
						 float timesToDamage,
							bool createEffect=true)
		{
			if(m_invincible)
			{
				return;
			}
			
			//decrease the number of hits
			float damageScalar = regularScalar;
			if(createEffect==false)
			{
				damageScalar = laserScalar;
			}
			m_nomHits-= (timesToDamage * damageScalar);
			if(createEffect || m_nomHits <=0)
			{
				m_gameScript.onHitBlock();
				
				
				if(damageScalar>0)
				{
					//create an object 
//					if(objectOnHit)
//					{
//						Instantiate( objectOnHit, onHit, Quaternion.identity);
//					}

					PoolSpawner.Instance.SpawnExplosion (onHit, Quaternion.identity);
				}
			}
			if(m_nomHits>0 && damageScalar>0)
			{
				Renderer ren = gameObject.GetComponent<Renderer>();
				if(ren)
				{
					Color color = ren.material.color;
					color*=0.5f;
					ren.material.color = color;
				}

			}
			
			//if we do not have any mroe hitshits remove the block
			if(m_nomHits<=0)
			{
				removeMe(false);
			}
		}

		public bool getDoneAOE()
		{
			return m_doneAOE;
		}
		public bool getDestroyed()
		{
			return m_destroyed;
		}

		public void damageArea(Vector3 pos, float radius)
		{
			Block[] blocks =(Block[]) GameObject.FindObjectsOfType(typeof(Block));
			//Debug.Log ("damageArea:"+blocks.Length);
			for(int i=0; i<blocks.Length;i++)
			{
				Vector3 vec = blocks[i].transform.position - pos;
	//			Debug.Log ("damageArea:"+vec.magnitude);

				if(vec.magnitude<30 && blocks[i].isPowerCore==false)
				{
					blocks[i].onHit(blocks[i].transform.position,damage,true);
				}
			}
		}

		public virtual void removeMe(bool hardcoreRemoval)
		{
			//remove the block
			if(m_destroyed==false)
			{
				if(isPowerCore)
				{
					damageArea(transform.position,aoeRadius);
				}

				//there are are times when we do not want to try and create a powerup (for example in the case of the nuke).
				if(hardcoreRemoval==false)
				{
					if(objectOnDeath)
					{
						Instantiate(objectOnDeath,transform.position,transform.rotation);
					}		
				}
				
				//add our score
				m_gameScript.addScore( bounty,false );

				BaseGameManager.destroyBlock(this);
				if(isPowerCore)
				{
					//inform the gamescript that the block has been removed
					m_gameScript.removeBlock();
				}	
				//set the block to destroyed
				m_destroyed=true;
				for(int i=0; i<transform.childCount; i++){
					transform.GetChild(i).transform.parent=transform.parent;
				}
			
				//actually remove the gameObject
				Destroy(gameObject);
			}
		}
		public float getNomHits()
		{
			return m_nomHits;
		}
	}
}
