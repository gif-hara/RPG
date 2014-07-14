/*===========================================================================*/
/*
*     * FileName    : BattleStateUpdateActiveTime.cs
*
*     * Description : アクティブタイムを更新するステート.
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
	/// アクティブタイムを更新するステート.
	/// </summary>
	public class BattleStateUpdateActiveTime : BattleStateElementBase
	{
		public BattleStateUpdateActiveTime()
			:base( BattleStateManager.State.UpdateActiveTime )
		{

		}

		public override void Enter (BattleStateManager owner)
		{
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.StartUpdateActiveTimeMessage );
		}

		public override void Update (BattleStateManager owner)
		{
		}

		public override void Exit (BattleStateManager owner)
		{
		}
	}
}
