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
		public BattleAllyPartyManager AllyPartyManager{ get{ return refAllyPartyManager; } }
		[SerializeField]
		private BattleAllyPartyManager refAllyPartyManager;

		/// <summary>
		/// コマンド入力を行っている味方データ.
		/// </summary>
		/// <value>The current command select ally data.</value>
		public AllyData CurrentCommandSelectAllyData{ private set; get; }

		/// <summary>
		/// 入力操作ステートマシン.
		/// </summary>
		private StateMachine<BattleAllyCommandSelector> inputArrowStateMachine;

		private Factory<CommandData> commandDataFactory;

		private CommandData temporaryCommandData = null;

		void Awake()
		{
			this.inputArrowStateMachine = new StateMachine<BattleAllyCommandSelector>( this );
			this.inputArrowStateMachine.Add( new MainCommandInput() );
			this.inputArrowStateMachine.Add( new AllyCommandInput() );

			this.commandDataFactory = new Factory<CommandData>();
			this.commandDataFactory.Add( new AttackCommandData() );
			this.commandDataFactory.Add( new CoverUpCommandData() );
		}
		void Update()
		{
			if( !IsPossibleInput )	return;

			this.inputArrowStateMachine.Update();
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartCommandSelectMessage )]
		void OnStartCommandSelect()
		{
			this.CurrentCommandSelectAllyData = refAllyPartyManager.Party.List.Find( a => a.SelectCommandType == BattleTypeConstants.CommandType.None );

			if( this.CurrentCommandSelectAllyData == null )	return;

			ChangeInputState( BattleTypeConstants.CommandSelectType.Main );
		}

		public void Decision( int commandId )
		{
			CurrentCommandSelectAllyData.DecisionCommand( BattleTypeConstants.CommandType.Attack );
			var tempAllyData = this.CurrentCommandSelectAllyData;
			this.CurrentCommandSelectAllyData = null;
			this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.DecisionCommandMessage, tempAllyData );
		}

		public void CreateCommandData( BattleTypeConstants.CommandType type )
		{
			this.temporaryCommandData = this.commandDataFactory.Clone( (int)type );
		}

		public void ChangeInputState( BattleTypeConstants.CommandSelectType type )
		{
			this.inputArrowStateMachine.Change( (int)type );
		}

		/// <summary>
		/// 入力可能か返す.
		/// </summary>
		/// <value><c>true</c> if this instance is possible input; otherwise, <c>false</c>.</value>
		private bool IsPossibleInput
		{
			get
			{
				return this.CurrentCommandSelectAllyData != null;
			}
		}
	}
}
