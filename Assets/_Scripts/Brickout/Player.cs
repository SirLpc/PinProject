using UnityEngine;
using System.Collections;
using InaneGames;
using UnityEngine.UI;

namespace InaneGames {

	public class Player : MonoBehaviour {

		private Image m_bar;
		private int chargeAmmount = 200;
		private int m_chargeAmmount = 0;

		//dont add energy if we destroyed the block while using the laser.
		private bool m_laserOff=false;

		private bool m_ballActive = false;

	
		void Start () {

		}
		void OnEnable()
		{
			GameManager.onFireBall += onFireBall;
			BaseGameManager.onDestroyBlock += onDestroyBlock;
			GameManager.onBallOutOfBounds += onBallOutOfBounds;
			GameManager.onGameOver += onGameOver;
			GameManager.onNewStack += onNewStack;		
		}
		void OnDisable()
		{
			BaseGameManager.onDestroyBlock -= onDestroyBlock;

			GameManager.onFireBall-= onFireBall;
			GameManager.onBallOutOfBounds -= onBallOutOfBounds;
			GameManager.onGameOver -= onGameOver;
			GameManager.onNewStack -= onNewStack;		
		}
		void onDestroyBlock(Block b)
		{
			if(m_laserOff==false)
			{
				m_chargeAmmount+=b.bounty;
				m_chargeAmmount = Mathf.Clamp(m_chargeAmmount,0,chargeAmmount);
			}
		}
		void onNewStack(int stackIndex)
		{
			onBallOutOfBounds();
		}
		void onGameOver( bool vic)
		{
			onBallOutOfBounds();
		}
		void onBallOutOfBounds()
		{
	//		setPowerbarActive(false);
			m_ballActive=false;

		}
		void onFireBall()
		{
			m_ballActive=true;
	//		setPowerbarActive(true);
		}
		void Update()
		{
			GameObject go =  GameObject.Find("LaserImage");
			if(go)
			{
				m_bar =go.GetComponent<Image>();
			}
			float val = m_chargeAmmount / (float)chargeAmmount;
//			m_val=val;
			if(m_bar && m_ballActive)
			{

				m_bar.fillAmount=val;	

				handleInput();

			}
			
			
		}
		
		void handleInput()
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				tryUseLaser();
			}
		}
		
		void tryUseLaser()
		{
			float val = m_chargeAmmount / (float)chargeAmmount;

			if(val>=1)
			{
				GameManager.startLaser();
				StartCoroutine(handleLaserIE());
				m_chargeAmmount=0;
				m_laserOff=true;
			}
		}
		public IEnumerator handleLaserIE()
		{
			yield return new WaitForSeconds(0.5f);
			GameManager.endLaser();
			m_laserOff=false;
		}


	}
}
