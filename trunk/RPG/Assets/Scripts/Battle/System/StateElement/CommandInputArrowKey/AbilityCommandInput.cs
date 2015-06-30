using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// 特殊能力コマンド選択時のキー操作クラス.
	/// </summary>
	public class AbilityCommandInput : CommandInputElementBase
	{
		public AbilityCommandInput()
			:base( BattleTypeConstants.CommandSelectType.Ability )
		{
		}

		public override void DecisionAction (BattleAllyCommandSelector owner)
		{
			owner.DecideMainCommand( commandId );
		}

		public override void CancelAction (BattleAllyCommandSelector owner)
		{
			Development.TODO( "キャンセル処理の実装" );
		}

		public override void LeftAction (BattleAllyCommandSelector owner)
		{
			commandId -= 3;
			if( commandId < 0 )
			{
				commandId += 6;
			}
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.ModifiedCommandIdMessage, commandId );
		}

		public override void RightAction (BattleAllyCommandSelector owner)
		{
			commandId += 3;
			if( commandId >= 6 )
			{
				commandId -= 6;
			}
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.ModifiedCommandIdMessage, commandId );
		}

		public override void UpAction (BattleAllyCommandSelector owner)
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

		public override void DownAction (BattleAllyCommandSelector owner)
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

		private int ConvertCommandType( BattleAllyCommandSelector owner )
		{
			return commandId;
		}
	}
}
