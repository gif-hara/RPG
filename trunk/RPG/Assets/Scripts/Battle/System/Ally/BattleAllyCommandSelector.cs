/*===========================================================================*/
/*
*     * FileName    : BattleAllyCommandSelector.cs
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
		private StateMachine<BattleAllyCommandSelector, CommandInputElementBase> inputArrowStateMachine;

		/// <summary>
		/// メインコマンドのイベントデータを保持したゲームオブジェクトリスト.
		/// </summary>
		[SerializeField]
		private List<GameObject> refMainCommandEventHolders;

		/// <summary>
		/// 敵コマンドのイベントデータを保持したゲームオブジェクト.
		/// </summary>
		[SerializeField]
		private GameObject refEnemyCommandEventHolder;

		/// <summary>
		/// 入力処理が可能であるか.
		/// </summary>
		private bool canInput = true;

		/// <summary>
		/// 編集中のコマンドデータ.
		/// </summary>
		/// <value>The command data.</value>
		public CommandData CommandData{ private set; get; }

		void Awake()
		{
			this.inputArrowStateMachine = new StateMachine<BattleAllyCommandSelector, CommandInputElementBase>( this );
			this.inputArrowStateMachine.Add( new MainCommandInput() );
			this.inputArrowStateMachine.Add( new AllyCommandInput() );
			this.inputArrowStateMachine.Add( new EnemyCommandInput() );
		}

		void OnInputLeft()
		{
			if( !this.IsPossibleInput )
			{
				return;
			}

			this.inputArrowStateMachine.Current.LeftAction( this );
		}

		void OnInputRight()
		{
			if( !this.IsPossibleInput )
			{
				return;
			}
			
			this.inputArrowStateMachine.Current.RightAction( this );
		}
		
		void OnInputUp()
		{
			if( !this.IsPossibleInput )
			{
				return;
			}
			
			this.inputArrowStateMachine.Current.UpAction( this );
		}
		
		void OnInputDown()
		{
			if( !this.IsPossibleInput )
			{
				return;
			}
			
			this.inputArrowStateMachine.Current.DownAction( this );
		}
		
		void OnInputDecide()
		{
			if( !this.IsPossibleInput )
			{
				return;
			}
			
			this.inputArrowStateMachine.Current.DecisionAction( this );
		}
		
		void OnInputCancel()
		{
			if( !this.IsPossibleInput )
			{
				return;
			}
			
			this.inputArrowStateMachine.Current.CancelAction( this );
		}
		

		[Attribute.MessageMethodReceiver( BattleMessageConstants.StartCommandSelectMessage )]
		void OnStartCommandSelect()
		{
			this.CurrentCommandSelectAllyData = refAllyPartyManager.Party.List.Find( a => a.SelectCommandType == BattleTypeConstants.CommandType.None );

			if( this.CurrentCommandSelectAllyData == null )	return;

			this.CommandData = new CommandData();
			ChangeInputState( BattleTypeConstants.CommandSelectType.Main );
			StartCoroutine( LockInputCoroutine() );
		}

		/// <summary>
		/// メインコマンドの決定処理
		/// </summary>
		/// <param name="id">Identifier.</param>
		public void DecideMainCommand( int id )
		{
			this.BroadcastMessage( refMainCommandEventHolders[id], BattleMessageConstants.DecideCommandMessage, id );
		}

		/// <summary>
		/// 敵コマンドの決定処理.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public void DecideEnemyCommand( int id )
		{
			this.BroadcastMessage( refEnemyCommandEventHolder, BattleMessageConstants.DecideCommandMessage, id );
		}

		/// <summary>
		/// コマンド選択完了処理.
		/// </summary>
		public void Complete()
		{
			this.CurrentCommandSelectAllyData.DecisionCommand( CommandData );
			var tempAllyData = this.CurrentCommandSelectAllyData;
			this.CurrentCommandSelectAllyData = null;
			this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.CompleteCommandSelectMessage, tempAllyData );
		}

		public void Cancel()
		{
			this.CommandData = new CommandData();
			ChangeInputState( BattleTypeConstants.CommandSelectType.Main );
		}

		public void ChangeInputState( BattleTypeConstants.CommandSelectType type )
		{
			this.inputArrowStateMachine.Change( (int)type );
		}

		private IEnumerator LockInputCoroutine()
		{
			this.canInput = false;

			yield return new WaitForEndOfFrame();

			this.canInput = true;
			Debug.Log( "Unlock" );
		}

		/// <summary>
		/// 入力可能か返す.
		/// </summary>
		/// <value><c>true</c> if this instance is possible input; otherwise, <c>false</c>.</value>
		private bool IsPossibleInput
		{
			get
			{
				return this.canInput && this.CurrentCommandSelectAllyData != null;
			}
		}
	}
}
