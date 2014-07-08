/*===========================================================================*/
/*
*     * FileName    :BattleSceneManager.cs
*
*     * Description : バトルシーンのルートコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Battle;

namespace RPG.Battle
{
	/// <summary>
	/// バトルシーンのルートコンポーネント.
	/// </summary>
	public class BattleSceneManager : MyMonoBehaviour
	{
		/// <summary>
		/// デバッグフラグ.
		/// </summary>
		[SerializeField]
		private bool isDebug;

		[SerializeField]
		private InitializeData debugInitializeData;

		void Start ()
		{
			if( isDebug )
			{
				SharedData.initializeData = debugInitializeData;
			}
			this.BroadcastMessage( this, BattleMessageConstants.PreInitializeSystemMessage );
		}
	}
}
