using UnityEngine;
using System.Collections;
namespace InaneGames {

	public class Ball : MonoBehaviour 
	{
		//the speed of the ball
		public float ballSpeed = 45f;

		//the damage the ball does per hit
		public int damagePerHit = 1;
		
		//the inital position of the ball -- if the ball goes out of bounds and you have 0 balls it will respawn at this location.
		private Vector3 m_initalPos;

		BrickoutGameScript _gameScript = null;
		public BrickoutGameScript gameScript
		{
			get{ 
				if (_gameScript != null)
					return _gameScript;

				_gameScript = BrickoutGameScript.Instance;
				return _gameScript;
			}
		}
		
		//the starting velocity
		public Vector3 startVelocity;

		//the rotation speed
		public Vector3 rotationSpeed = Vector3.zero;


		private Rigidbody m_body;
		public virtual void Awake()
		{
			//grab the inital position of the ball
			m_initalPos = transform.position;

			m_body = gameObject.GetComponent<Rigidbody>();
		}

		public void OnEnable()
		{
			GameManager.onBallHitPaddle += onBallHitPaddle;
		}
		public void OnDisable()
		{
			GameManager.onBallHitPaddle -= onBallHitPaddle;
		}
		public void delete()
		{
			Destroy(gameObject,0.1f);
		}

		public void reflect(Vector3 vec)
		{
			vec = -transform.position;
			vec.y = transform.position.y;
			
			m_body.velocity = vec.normalized * ballSpeed;
		}

		//reset the ball back to its origianl positon
		public void reset()
		{
			transform.position = m_initalPos;
			
			//if its not kinematic zero out the velocity and angular velocity
			if(m_body.isKinematic==false)
			{
				m_body.velocity = Vector3.zero;
				m_body.angularVelocity = rotationSpeed;
			}
		}
		public void fire()
		{
			if(gameScript && gameScript.isGameOver()==false)
			{
				//fire the ball in straight down...
				if(m_body.isKinematic==false)
				{	
					m_body.velocity = startVelocity.normalized * ballSpeed;
				}
			}
		}
		void Update()
		{
			
			if(gameScript && gameScript.isGameOver()==false)
			{		
				//move the ball at a constant speed
				moveAtConstantSpeed();
			}
			else{
				if(m_body.isKinematic==false)
				{	
					m_body.velocity = Vector3.zero;			
				}
			}

		}


		void OnCollisionEnter(Collision col)
		{
			Block block = col.gameObject.GetComponent<Block>();
			if(block)
			{
				handleBlock(block,col.contacts[0].point);
			}
		
			Paddle paddle = col.gameObject.GetComponent<Paddle>();
			if(paddle==null && col.transform && col.transform.parent)
			{
				paddle = col.transform.parent.GetComponent<Paddle>();
			}
	
		}
		
		void onBallHitPaddle(Paddle p, Ball b)
		{
			Vector3 pos =transform.position;
			pos.x*=-1;
			pos.z*=-1;
			if(m_body)
			{	
				m_body.velocity = pos.normalized * ballSpeed;
			}
		}

		void handleBlock(Block block,Vector3 pos)
		{
			//handle the case where we have hitten a block
			if(block)
			{
				block.onHit(pos, damagePerHit);
			}
		}

		void moveAtConstantSpeed()
		{
			Vector3 vec = m_body.velocity;
			if(m_body.isKinematic==false)
			{	
				m_body.velocity = vec.normalized * ballSpeed;
			}	
		}
		

		
	}

}
