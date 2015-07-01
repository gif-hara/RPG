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
		}
		
		public override void DecisionAction (BattleAllyCommandSelector owner)
		{
			owner.DecideAllyCommand( commandId );
		}
		
		public override void CancelAction (BattleAllyCommandSelector owner)
		{
			owner.Cancel();
		}
		
		public override void LeftAction (BattleAllyCommandSelector owner)
		{
		}
		
		public override void RightAction (BattleAllyCommandSelector owner)
		{
		}
		
		public override void UpAction (BattleAllyCommandSelector owner)
		{
			commandId -= 1;
			if( commandId == -1 )
			{
				commandId = owner.AllyPartyManager.Party.List.Count - 1;
			}

			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.ModifiedCommandIdMessage, commandId );
		}
		
		public override void DownAction (BattleAllyCommandSelector owner)
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
