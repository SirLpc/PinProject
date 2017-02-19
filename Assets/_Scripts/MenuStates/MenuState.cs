using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace InaneGames
{
	public class MenuState : MonoBehaviour {
		public GameObject fadeOut;

		public GameObject mainGO;
		public GameObject creditsGO;
		public GameObject optionsGO;
		public GameObject levelSelectGO;

		public Button audioButton;

		public void Awake()
		{
			updateAudio();
		}

		public void closeLevelSelect()
		{
			openClose(levelSelectGO,mainGO);
		}	
		public void closeOptionsMenu()
		{
			openClose(optionsGO,mainGO);
		}
		public void closeCreditsMenu()
		{
			openClose(creditsGO,mainGO);
		}
		public void openLevelSelect()
		{
			openClose(mainGO,levelSelectGO);
		}	
		public void openOptionsMenu()
		{
			openClose(mainGO,optionsGO);
		}
		public void openCreditsMenu()
		{
			openClose(mainGO,creditsGO);
		}
		

		public void startGame()
		{
			loadLevel(1);
		}
		public void continueGame()
		{
			loadLevel(Misc.getMaxLevel());
		}
		public void loadLevel(int levelIndex)
		{
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
		public void toggleAudio()
		{
			if(AudioListener.volume==0)
			{
				AudioListener.volume = 1.0F;
			}else{
				AudioListener.volume = 0.0F;
				
			}
			updateAudio();
		}
		public void updateAudio()
		{
			if(audioButton)
			{
				Text text = audioButton.GetComponentInChildren<Text>();
				if(text)
				{
					if(AudioListener.volume==0)
					{
						text.text = "AUDIO: OFF"; 
					}else{
						text.text = "AUDIO: ON";
					}
				}
			}
		}
		
		public void deleteData()
		{
			PlayerPrefs.DeleteAll();
		}
		void openClose(GameObject go1, GameObject go2)
		{
//			Debug.Log ("openClose" + go1.name + "close " + go2.name + " open");
			//if(go1)
			{
				go1.SetActive(false);
			}
			//.if(go2)
			{
				go2.SetActive(true);
			}
			
		}
	}
}
