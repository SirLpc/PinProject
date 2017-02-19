using UnityEngine;
using System.Collections;
namespace InaneGames {

	public class Globals : MonoBehaviour {
		public enum State
		{
			NOM_LIVES,
			TOTAL_SCORE
		};
		
		public enum Upgrade
		{
			INITAL_LIVES,
			MAX_LIVES
		};
		public static void setIntValue(Upgrade state, int defaulVal)
		{
			PlayerPrefs.SetInt(toString(state),defaulVal);		
		}
		public static int getIntValue(Upgrade state, int defaulVal)
		{
			return PlayerPrefs.GetInt(toString(state),defaulVal);		
		}
		
		
		public static void setIntValue(State state, int defaulVal)
		{
			PlayerPrefs.SetInt(toString(state),defaulVal);		
		}
		public static int getIntValue(State state, int defaulVal)
		{
			return PlayerPrefs.GetInt(toString(state),defaulVal);		
		}
		
		public static void setNomLives(int val)
		{
			setIntValue(State.NOM_LIVES,val);
		}
		public static int getNomLives(int defaultVal)
		{
			return getIntValue(State.NOM_LIVES,defaultVal);
		}
		
		public static void setTotalScore(int val)
		{
			setIntValue(State.TOTAL_SCORE,val);

		}
		public static int getTotalScore(int defaultVal)
		{
			return getIntValue(State.TOTAL_SCORE,defaultVal);
		}
		public static string toString(Upgrade con)
		{
			return con.ToString();
		}
		public static string toString(State con)
		{
			return con.ToString();
		}
	}
}
