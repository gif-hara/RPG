/*===========================================================================*/
/*
*     * FileName    : EnemyCommandInput.cs
*
*     * Description : 敵選択コマンド選択時のキー操作クラス.
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
	/// 敵選択コマンド選択時のキー操作クラス.
	/// </summary>
	public class EnemyCommandInput : CommandInputElementBase
	{
		public EnemyCommandInput()
			:base( BattleTypeConstants.CommandSelectType.Enemy )
		{
		}
		
		public override void Enter (BattleAllyCommandSelector owner)
		{
			base.Enter (owner);
			var parameter = new BattleMessageConstants.OpenCommandWindowData( BattleTypeConstants.CommandSelectType.Enemy, owner.CurrentCommandSelectAllyData );
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.OpenCommandWindowMessage, parameter );
		}
		
		protected override void DecisionAction (BattleAllyCommandSelector owner)
		{
		}
		
		protected override void CancelAction (BattleAllyCommandSelector owner)
		{
			owner.Cancel();
		}
		
		protected override void LeftAction (BattleAllyCommandSelector owner)
		{
		}
		
		protected override void RightAction (BattleAllyCommandSelector owner)
		{
		}
		
		protected override void UpAction (BattleAllyCommandSelector owner)
		{
			commandId -= 1;
			if( commandId == -1 )
			{
				commandId = 2;
			}
			else if( commandId == 2 )
			{
				commandId = 5;
			}
			
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.ModifiedCommandIdMessage, commandId );
		}
		
		protected override void DownAction (BattleAllyCommandSelector owner)
		{
			commandId += 1;
			if( commandId == 3 )
			{
				commandId = 0;
			}
			else if( commandId == 6 )
			{
				commandId = 3;
			}
			
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.ModifiedCommandIdMessage, commandId );
		}
	}
}
