/*===========================================================================*/
/*
*     * FileName    : AllyCommandInput.cs
*
*     * Description : 味方選択時のキー操作クラス.
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
	/// 味方選択時のキー操作クラス.
	/// </summary>
	public class AllyCommandInput : CommandInputElementBase
	{
		public AllyCommandInput()
			:base( BattleTypeConstants.CommandSelectType.Ally )
		{
		}
		
		public override void Enter (BattleAllyCommandSelector owner)
		{
			base.Enter (owner);
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.OpenCommandWindowMessage, BattleTypeConstants.CommandSelectType.Ally );
		}
		
		protected override void DecisionAction (BattleAllyCommandSelector owner)
		{
			owner.CommandData.AddTargetId( commandId );
			owner.Complete();
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
				commandId = owner.AllyPartyManager.Party.List.Count - 1;
			}

			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.ModifiedCommandIdMessage, commandId );
		}
		
		protected override void DownAction (BattleAllyCommandSelector owner)
		{
			commandId += 1;
			if( commandId == owner.AllyPartyManager.Party.List.Count )
			{
				commandId = 0;
			}

			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.ModifiedCommandIdMessage, commandId );
		}
	}
}
