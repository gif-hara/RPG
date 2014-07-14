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
		[SerializeField]
		private BattleAllyPartyManager refAllyPartyManager;

		private AllyData currentCommandSelectAllyData = null;

		private StateMachine<BattleAllyCommandSelector> inputArrowStateMachine;

		void Awake()
		{
			this.inputArrowStateMachine = new StateMachine<BattleAllyCommandSelector>( this );
			this.inputArrowStateMachine.Add( new MainCommandInput() );
		}
		void Update()
		{
			if( !IsPossibleInput )	return;

			this.inputArrowStateMachine.Update();
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartCommandSelectMessage )]
		void OnStartCommandSelect()
		{
			this.currentCommandSelectAllyData = refAllyPartyManager.Party.List.Find( a => a.SelectCommandType == BattleTypeConstants.CommandType.None );

			if( this.currentCommandSelectAllyData == null )	return;

			this.inputArrowStateMachine.Change( (int)BattleTypeConstants.CommandSelectType.Main );
			this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.SelectCommandSelectCharacterMessage, this.currentCommandSelectAllyData );
		}

		private void DecisionCommand()
		{
			currentCommandSelectAllyData.DecisionCommand( BattleTypeConstants.CommandType.Attack );
			var tempAllyData = this.currentCommandSelectAllyData;
			this.currentCommandSelectAllyData = null;
			this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.DecisionCommandMessage, tempAllyData );
		}

		private void InputArrowKey()
		{

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
