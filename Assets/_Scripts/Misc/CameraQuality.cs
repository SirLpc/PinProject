using UnityEngine;
using System.Collections;
namespace InaneGames {

	public class CameraQuality : MonoBehaviour {
		public int targetFramerate = 60;

		void Update () {
			Application.targetFrameRate = targetFramerate;
			int qualityLevel = QualitySettings.GetQualityLevel();
			MonoBehaviour mbc = (MonoBehaviour)gameObject.GetComponent("GlowEffect");
			if(mbc)
			{
				mbc.enabled= (qualityLevel > 0);
			}
			
			mbc = (MonoBehaviour)gameObject.GetComponent("ContrastEnhance");
			if(mbc)
			{
				mbc.enabled= (qualityLevel > 1);
			}
		}
		

	}
}