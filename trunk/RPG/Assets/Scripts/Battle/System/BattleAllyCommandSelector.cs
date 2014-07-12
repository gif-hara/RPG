/*===========================================================================*/
/*
*     * FileName    : BattleAllyCommandSelector.cs
*
*     * Description : 味方のコマンドを選択するコンポーネント.
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
	/// 味方のコマンドを選択するコンポーネント.
	/// </summary>
	public class BattleAllyCommandSelector : MyMonoBehaviour
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
			if( !IsPossibleInput )	return;

			if( Input.GetKeyDown( KeyCode.Space ) )
			{
				TODO( "コマンド選択処理の実装." );
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

		/// <summary>
		/// 入力可能か返す.
		/// </summary>
		/// <value><c>true</c> if this instance is possible input; otherwise, <c>false</c>.</value>
		private bool IsPossibleInput
		{
			get
			{
				return this.currentCommandSelectAllyData != null;
			}
		}
	}
}
