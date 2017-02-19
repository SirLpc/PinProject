using UnityEngine;
using System.Collections;
namespace InaneGames {

	public class InitState : MonoBehaviour {

		public UnityEngine.UI.Text levelText;

		
		// Update is called once per frame
		void Awake () {
			
			if(levelText)
			{
				levelText.text = "Level" + Application.loadedLevel;
			}

		}
	}
}