/*===========================================================================*/
/*
*     * FileName    : BattleAllyCommandManager.cs
*
*     * Description : プレイヤーのコマンドを管理するコンポーネント.
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
	/// プレイヤーのコマンドを管理するコンポーネント.
	/// </summary>
	public class BattleAllyCommandManager : MyMonoBehaviour
	{
		/// <summary>
		/// コマンドデータ.
		/// </summary>
		public class CommandData
		{
			public CharacterData Data{ private set; get; }

			public bool IsInput{ private set; get; }

			public CommandData( CharacterData data )
			{
				this.Data = data;
				this.IsInput = true;
			}
		}

		[SerializeField]
		private BattleAllyPartyManager refAllyPartyManager;

		private BattleAllyPartyManager.AllyData currentCommandSelectAllyData = null;

		void Update()
		{
			if( Input.GetKeyDown( KeyCode.Space ) )
			{
				DecisionCommand();
			}
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartCommandSelectMessage )]
		void OnStartCommandSelect()
		{
			this.currentCommandSelectAllyData = refAllyPartyManager.Party.List.Find( a => a.SelectCommandType == BattleTypeConstants.CommandType.None );

			if( this.currentCommandSelectAllyData == null )	return;

			this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.SelectCommandSelectCharacterMessage, this.currentCommandSelectAllyData );
		}

		private void DecisionCommand()
		{
			currentCommandSelectAllyData.DecisionCommand( BattleTypeConstants.CommandType.UsualAttack );
			var tempAllyData = this.currentCommandSelectAllyData;
			this.currentCommandSelectAllyData = null;
			this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.DecisionCommandMessage, tempAllyData );
		}
	}
}
