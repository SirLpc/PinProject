using UnityEngine;
using System.Collections;
namespace InaneGames {

	public class GameManager  {

		public delegate void OnGameStart();
		public static event OnGameStart onGameStart;
		public static void startGame()
		{
			if(onGameStart!=null)
			{
				onGameStart();
			}
		}
		public delegate void OnBallHitPaddle(Paddle p, Ball b);
		public static event OnBallHitPaddle onBallHitPaddle;
		public static void ballHitPaddle(Paddle p, Ball b)
		{
			if(onBallHitPaddle!=null)
			{
				onBallHitPaddle(p,b);
			}
		}
		
		public delegate void OnGamePause();
		public static event OnGamePause onGamePause;
		public static void pauseGame()
		{
			if(onGamePause!=null)
			{
				onGamePause();
			}
		}

		public delegate void OnFireBall();
		public static event OnFireBall onFireBall;
		public static void fireBall()
		{
			if(onFireBall!=null)
			{
				onFireBall();
			}
		}

		
		public delegate void OnLaserStart();
		public static event OnLaserStart onLaserStart;
		public static void startLaser()
		{
			if(onLaserStart!=null)
			{
				onLaserStart();
			}
		}
		public delegate void OnLaserEnd();
		public static event OnLaserEnd onLaserEnd;
		public static void endLaser()
		{
			if(onLaserEnd!=null)
			{
				onLaserEnd();
			}
		}
		
		public delegate void OnBallOutOfBounds();
		public static event OnBallOutOfBounds onBallOutOfBounds;
		public static void ballOutOfBounds()
		{
			if(onBallOutOfBounds!=null)
			{
				onBallOutOfBounds();
			}
		}
		
		
		public delegate void OnGameOver(bool vi);
		public static event OnGameOver onGameOver;
		public static void gameOver(bool vic)
		{
			if(onGameOver!=null)
			{
				onGameOver(vic);
			}
		}
		
		public delegate void OnRotatePaddle(float val);
		public static event OnRotatePaddle onRotatePaddle;
		public static void rotatePaddle(float val)
		{
			if(onRotatePaddle!=null)
			{
				onRotatePaddle(val);
			}
		}
		
		public delegate void OnNewStack(int stackIndex);
		public static event OnNewStack onNewStack;
		public static void newStack(int stackIndex)
		{
			if(onNewStack!=null)
			{
				onNewStack(stackIndex);
			}
		}
	}	
}
