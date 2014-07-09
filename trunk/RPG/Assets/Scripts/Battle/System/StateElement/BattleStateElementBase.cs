/*===========================================================================*/
/*
*     * FileName    : BattleStateElementBase.cs
*
*     * Description : バトルのステート要素抽象クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// バトルのステート要素抽象クラス.
	/// </summary>
	public abstract class BattleStateElementBase : StateElementBase<BattleStateManager>
	{
		public BattleStateElementBase( BattleStateManager.State state )
			:base( (int)state )
		{
		}

		protected void BroadcastMessage( MonoBehaviour sender, string methodName )
		{
			MyMonoBehaviour.BroadcastMessage( sender, methodName );
		}
		protected void BroadcastMessage( MonoBehaviour sender, string methodName, object parameter )
		{
			MyMonoBehaviour.BroadcastMessage( sender, methodName, parameter );
		}
	}
}
