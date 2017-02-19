using UnityEngine;
using System.Collections;
namespace InaneGames
{

	public class GameMenuHandler : MonoBehaviour {
		BrickoutGameScript m_gameScript;
		public GameObject initMenu;
		public GameObject gameMenu;
		public GameObject pauseMenu;
		public GameObject resultsMenu;
		public GameObject fadeOut;

		public void Update()
		{
			if(m_gameScript==null)
			{
				m_gameScript = BrickoutGameScript.Instance;
				if(m_gameScript)
				{
					m_gameScript.initMenu = initMenu;
					m_gameScript.gameMenu = gameMenu;
					m_gameScript.pauseMenu = pauseMenu;
					m_gameScript.resultsMenu = resultsMenu;
					m_gameScript.fadeOut = fadeOut;
				}

			}
		}
		public void setPaused(bool paused)
		{
			if(m_gameScript)
			{
				m_gameScript.setPaused(paused);
			}
		}
	
		public void reloadLevel()
		{
			if(m_gameScript)
			{
				m_gameScript.reloadLevel();
			}
		}
		public void loadNextLevel()
		{
			if(m_gameScript)
			{
				m_gameScript.loadNextLevel();
			}
		}
		public void loadMenu()
		{
			if(m_gameScript)
			{
				m_gameScript.loadMenu();
			}
		}
		


		public void start()
		{
			if(m_gameScript)
			{
				m_gameScript.start();
			}
		}



	}
}