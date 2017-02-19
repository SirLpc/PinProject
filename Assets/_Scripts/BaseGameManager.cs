using UnityEngine;
using System.Collections;
namespace InaneGames {
/// <summary>
/// Base game manager.
/// </summary>
public class BaseGameManager  {

		public delegate void OnDestroyBlock(Block	 block);
		public static event OnDestroyBlock onDestroyBlock;
		public static void destroyBlock(Block block)
		{
			if(onDestroyBlock!=null)
			{
				onDestroyBlock(block	);	
			}
		}
	
	
}
}
