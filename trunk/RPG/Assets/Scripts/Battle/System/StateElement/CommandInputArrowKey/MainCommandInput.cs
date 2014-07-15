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

		public override void Enter (BattleAllyCommandSelector owner)
		{
			base.Enter (owner);
			var parameter = new BattleMessageConstants.OpenCommandWindowData( BattleTypeConstants.CommandSelectType.Main, owner.CurrentCommandSelectAllyData );
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.OpenCommandWindowMessage, parameter );
		}

		protected override void DecisionAction (BattleAllyCommandSelector owner)
		{
			if( commandId != 0 && commandId != 4 )
			{
				MyMonoBehaviour.TODO( "戦う以外のコマンド実装." );
				return;
			}

			owner.CreateCommandData( (BattleTypeConstants.CommandType)(commandId + 1) );
			owner.ChangeInputState( NextCommandSelectType );
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

		private BattleTypeConstants.CommandSelectType NextCommandSelectType
		{
			get
			{
				BattleTypeConstants.CommandSelectType[] types =
				{
					BattleTypeConstants.CommandSelectType.Enemy,
					BattleTypeConstants.CommandSelectType.Ability,
					BattleTypeConstants.CommandSelectType.Item,
					BattleTypeConstants.CommandSelectType.Main,
					BattleTypeConstants.CommandSelectType.Ally,
					BattleTypeConstants.CommandSelectType.Main,
				};

				return types[commandId];
			}
		}

	}
}
