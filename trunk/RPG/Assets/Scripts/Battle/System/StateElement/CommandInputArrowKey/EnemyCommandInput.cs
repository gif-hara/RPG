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
		int max = 0;

		public EnemyCommandInput()
			:base( TypeConstants.CommandSelectType.Enemy )
		{
		}
		
		public override void Enter (BattleAllyCommandSelector owner)
		{
			base.Enter (owner);
			this.max = owner.EnemyPartyManager.GroupCount;
		}
		
		public override void DecisionAction (BattleAllyCommandSelector owner)
		{
			owner.DecideEnemyCommand( commandId );
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
				commandId = this.max - 1;
			}

			BroadcastMessage( SceneRootBase.Root, MessageConstants.ModifiedCommandIdMessage, commandId );
		}
		
		public override void DownAction (BattleAllyCommandSelector owner)
		{
			commandId += 1;
			if( commandId == this.max )
			{
				commandId = 0;
			}

			BroadcastMessage( SceneRootBase.Root, MessageConstants.ModifiedCommandIdMessage, commandId );
		}
	}
}
