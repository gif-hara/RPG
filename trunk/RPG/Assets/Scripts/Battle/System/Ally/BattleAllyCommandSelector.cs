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

		public BattleEnemyPartyManager EnemyPartyManager{ get{ return refEnemyPartyManager; } }
		[SerializeField]
		private BattleEnemyPartyManager refEnemyPartyManager;

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
			this.inputArrowStateMachine.Add( new EnemyCommandInput() );

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

		public void Decision()
		{
			CurrentCommandSelectAllyData.DecisionCommand( temporaryCommandData );
			var tempAllyData = this.CurrentCommandSelectAllyData;
			this.CurrentCommandSelectAllyData = null;
			this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.DecisionCommandMessage, tempAllyData );
		}

		public void Cancel()
		{
			this.temporaryCommandData = null;
			ChangeInputState( BattleTypeConstants.CommandSelectType.Main );
		}

		public void CreateCommandData( BattleTypeConstants.CommandType type )
		{
			this.temporaryCommandData = this.commandDataFactory.Clone( (int)type );
			this.temporaryCommandData.Initialize( this );
		}

		public void ChangeInputState( BattleTypeConstants.CommandSelectType type )
		{
			this.inputArrowStateMachine.Change( (int)type );
		}

		/// <summary>
		/// コマンドデータの変更を受け入れる.
		/// </summary>
		/// <param name="acceptFunction">Accept function.</param>
		public void AcceptChangeCommandData( System.Action<CommandData> acceptFunction )
		{
			acceptFunction( this.temporaryCommandData );
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
