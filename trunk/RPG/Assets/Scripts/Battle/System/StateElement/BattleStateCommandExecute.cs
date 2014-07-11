/*===========================================================================*/
/*
*     * FileName    : BattleStateCommandExecute.cs
*
*     * Description : コマンドを実行するバトルステート.
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
	/// コマンドを実行するバトルステート.
	/// </summary>
	public class BattleStateCommandExecute : BattleStateElementBase
	{
		public BattleStateCommandExecute()
			:base( BattleStateManager.State.ExecuteCommand )
		{
			
		}
		
		public override void Enter (BattleStateManager owner)
		{
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.StartCommandExecuteMessage );
		}
		
		public override void Update (BattleStateManager owner)
		{
		}
		
		public override void Exit (BattleStateManager owner)
		{
		}
	}
}
