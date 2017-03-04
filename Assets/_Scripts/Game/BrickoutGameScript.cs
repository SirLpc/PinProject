using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace InaneGames {

	public class BrickoutGameScript : MonoBehaviour
	{
		public static BrickoutGameScript Instance = null;

		public int nomLives = 5;
		public GameObject [] stackArray;
		public AudioClip onHitAC;
		public Vector3 ballStartPos = Vector3.zero;
		public GameObject ballPrefab;
		
		public GameObject initMenu;
		public GameObject gameMenu;
		public GameObject pauseMenu;
		public GameObject resultsMenu;
		public GameObject fadeOut;

		public AudioClip outOfBoundsAC;
		public float shakeAndBakeTime=1;

		private AudioSource m_audio;

		public AudioClip[] getReadACs;
		public AudioClip extraLifeAC;
		public AudioClip nextRoundAC;
		public AudioClip lostAC;

		public string[] readStrings;
		public float waitTime=1f;


		private int m_nomLives = 0;
		private int m_blockCount=0;
		private int m_score = 0;
		private int m_lifeScore=0;
		private int m_stackIndex=0;
		private int m_extraLifeCost = 500;
		private bool m_gameOver=false;

		private List<Block> _blockList = new List<Block>();

		public GameObject stackRotatorGO;
		private GameObject m_stackRotator;
		public void Awake()
		{
			Instance = this;

			m_nomLives=nomLives;
			m_audio = gameObject.GetComponent<AudioSource>();

			m_stackRotator = (GameObject)Instantiate(stackRotatorGO,Vector3.zero,Quaternion.identity);
			//设置到这个下面就可以和外面的框一起动咯
			m_stackRotator.transform.SetParent (GameObject.Find ("ControlRotator").transform);
		}
		public void OnEnable()
		{
			GameManager.onGameOver+=onGameOver;
		}
		public void OnDisable()
		{
			GameManager.onGameOver-=onGameOver;
		}
		private void OnDestroy()
		{
			Instance = null;
		}

		void onGameOver(bool vic)
		{
			m_gameOver=true;
			if(vic)
			{
				Misc.setMaxLevel(Application.loadedLevel+1);	
			}else{
				if(m_audio)
				{
					m_audio.PlayOneShot(lostAC);
				}
			}

			if(resultsMenu)
			{
				resultsMenu.SetActive(true);
			}
		}
		public void Update()
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				togglePause();
			}
		}
		public void setPaused(bool paused)
		{
			Time.timeScale = (paused) ? 0 : 1;
			if(pauseMenu){
				pauseMenu.SetActive(Time.timeScale==0);
			}
		}
		void togglePause()
		{

			if(Time.timeScale==0)
			{
				Time.timeScale=1;
			}else{
				Time.timeScale=0;
			}
			setPaused(Time.timeScale==0	);
		}

		public void start()
		{
			GameManager.startGame();
			if(initMenu)
			{
				initMenu.SetActive(false);
			}
			if(gameMenu)
			{
				gameMenu.SetActive(true);
			}

			createNextStack();
		}

		public void addBlock(Block block)
		{
			m_blockCount++;
			_blockList.Add (block);
		}	
		public void onHitBlock()
		{
			m_stackRotator.SendMessage("onHitBlock");
			if(GetComponent<AudioSource>())
			{
				GetComponent<AudioSource>().clip = onHitAC;
				GetComponent<AudioSource>().Play();
			}
		}	


		public void newBall(bool lossBall=false)
		{
			Ball[] balls = (Ball[])GameObject.FindObjectsOfType(typeof(Ball));

			//if none are active
			if(balls.Length<=1)
			{
				if(balls.Length==1)
				{
					m_nomLives--;
				}		
				if(m_nomLives>0)
				{
					if(lossBall)
					{
						StartCoroutine(shakeAndBake());
					}else{
						StartCoroutine(waitForBall());
					}
				}else{
					//otherwise handle the defeat
					GameManager.gameOver(false);
				}
			}
		}
		
		public IEnumerator shakeAndBake()
		{
	//		_CameraShake.Shake();
			if(GetComponent<AudioSource>())
			{
				GetComponent<AudioSource>().PlayOneShot( outOfBoundsAC);
			}
			yield return new WaitForSeconds(shakeAndBakeTime);
			StartCoroutine(waitForBall());
		}
		//preform the countdown
		IEnumerator waitForBall()
		{

			Ball[] balls = (Ball[])GameObject.FindObjectsOfType(typeof(Ball));
			if(balls.Length==0)
			{
				GameObject go = (GameObject)Instantiate(ballPrefab,ballStartPos,Quaternion.identity);
				go.transform.localEulerAngles = Consts.PlayerDefalutRot;
				if(go)
				{
					Ball ball = go.GetComponent<Ball>();
					if(ball)
					{
						ball.reset();
					}
				}
			}
			if(m_gameOver==false)
			{
				for(int i=0; i<getReadACs.Length;i++)
				{
					if(m_audio)
					{
						m_audio.PlayOneShot(getReadACs[i]);
					}
					pushText(readStrings[i],Color.green);
					yield return new WaitForSeconds( waitTime ); 
				}
			}
			GameManager.fireBall();
			 balls = (Ball[])GameObject.FindObjectsOfType(typeof(Ball));


			for(int i=0; i<balls.Length; i++)
			{
				balls[i].fire();
			}
		}

		public void removeBlock(Block block)
		{
			if (_blockList.Contains (block)) {
				if (block && block.getNomHits () <= 0)
					_blockList.Remove (block);
			}

			//overGameDestroySpecific ();
			overGameDestroyAllEnemy();
		}

		void overGameDestroySpecific()
		{
			m_blockCount=0;
			foreach (var item in _blockList) 
			{
				if(item && item.getNomHits()>0 && item.isPowerCore){
					m_blockCount++;
				}
			}

			if(m_blockCount==0)
			{
				createNextStack();
			}	
		}

		void overGameDestroyAllEnemy()
		{
			if(_blockList.Count <= 0)
			{
				createNextStack();
			}
		}

		void createNextStack()
		{
			if(m_stackIndex+1 <= stackArray.Length)
			{

				GameManager.newStack(m_stackIndex);
				GameObject go;
				var pref = stackArray [m_stackIndex];
				if (!YourGlobalSettings.Instance.EditMapMode)
				{
					go = new GameObject("Stacks");
					var tr = go.transform;
					tr.position = ballStartPos;
					tr.rotation = pref.transform.rotation;
					go.AddComponent<ChapterDataReader> ();
				} 
				else
				{
					go = (GameObject)Instantiate(pref,ballStartPos,pref.transform.rotation);
					go.AddComponent<ChapterDataSaver> ();
				}
				if(go)
				{
					go.gameObject.transform.parent = m_stackRotator.transform;
				}
				int round = m_stackIndex+1;
				if(round>1)
				{
					pushText("Round " + round,Color.green);
					if(m_audio)
					{
						m_audio.PlayOneShot(nextRoundAC);
					}
				}
				m_stackIndex++;
				
				Ball[] balls = (Ball[])GameObject.FindObjectsOfType(typeof(Ball));
				for(int i=0; i<balls.Length;i++)
				{
					balls[i].reset();	
				}
				StartCoroutine(waitForBall());
			}
			else{
				GameManager.gameOver(true);
			}
		}
		public void reloadLevel(){
			loadLevel(Application.loadedLevel);
		}
		public void loadNextLevel(){
			loadLevel(Application.loadedLevel+1);
		}
		public void loadMenu(){
			loadLevel(0);
		}
		public void loadLevel(int levelIndex)
		{
			if(fadeOut)
			{
				fadeOut.SetActive(true);
			}
			StartCoroutine(loadLevelIE(levelIndex));
		}

		IEnumerator loadLevelIE(int levelIndex)
		{
			Time.timeScale=1;
			if(fadeOut)
			{
				fadeOut.SetActive(true);
			}
			yield return new WaitForSeconds(1);
			Application.LoadLevel(levelIndex);
		}
		void pushText(string str, Color color)
		{
	//		ScoreFlash.Push(str);
		}
		public void addScore(int score,
		                     bool powerup)
		{
			m_score+=score;
			m_lifeScore += score;
			if(m_lifeScore>=m_extraLifeCost)
			{
				m_lifeScore-=m_extraLifeCost;
				m_nomLives++;
				pushText("Extra Life",Color.green);	
				if(m_audio)
				{
					m_audio.PlayOneShot(extraLifeAC);
				}
			}
		}
		public bool isGameOver()
		{
			return m_gameOver;
		}
		public int getScore()
		{
			return m_score;
		}
		public int getNomLives()
		{
			return m_nomLives;
		}
	}
}
