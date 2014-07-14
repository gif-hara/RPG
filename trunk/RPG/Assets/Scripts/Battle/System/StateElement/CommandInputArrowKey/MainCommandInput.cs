/*===========================================================================*/
/*
*     * FileName    : MainCommandInput.cs
*
*     * Description : メインコマンド選択時のキー操作クラス.
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
	/// メインコマンド選択時のキー操作クラス.
	/// </summary>
	public class MainCommandInput : CommandInputElementBase
	{
		public MainCommandInput()
			:base( BattleTypeConstants.CommandSelectType.Main )
		{
		}

		protected override void DecisionAction (BattleAllyCommandSelector owner)
		{
			if( commandId != 0 )
			{
				MyMonoBehaviour.TODO( "戦う以外のコマンド実装." );
				return;
			}

			owner.Decision( commandId );
		}

		protected override void CancelAction (BattleAllyCommandSelector owner)
		{
		}

		protected override void LeftAction (BattleAllyCommandSelector owner)
		{
			commandId -= 3;
			if( commandId < 0 )
			{
				commandId += 6;
			}
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.ModifiedCommandIdMessage, commandId );
		}

		protected override void RightAction (BattleAllyCommandSelector owner)
		{
			commandId += 3;
			if( commandId >= 6 )
			{
				commandId -= 6;
			}
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.ModifiedCommandIdMessage, commandId );
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
