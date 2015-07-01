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
		public Ally CurrentCommandSelectAlly{ private set; get; }

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
		/// 味方コマンドのイベントデータを保持したゲームオブジェクト.
		/// </summary>
		[SerializeField]
		private GameObject refAllyCommandEventHolder;

		/// <summary>
		/// 特殊能力コマンドのイベントデータを保持したゲームオブジェクト.
		/// </summary>
		[SerializeField]
		private GameObject refAbilityCommandEventHolder;

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
			this.inputArrowStateMachine.Add( new AbilityCommandInput() );
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
			this.CurrentCommandSelectAlly = refAllyPartyManager.Party.NoneCommandBattleMember;
			Debug.Assert( this.CurrentCommandSelectAlly != null, "誰もActiveTimeが最大値ではありませんでした.", this );

			this.CommandData = new CommandData();
			StartCoroutine( LockInputCoroutine() );
			BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.OpenCommandWindowMessage, BattleTypeConstants.CommandSelectType.Main );
		}

		[Attribute.MessageMethodReceiver( BattleMessageConstants.OpenCommandWindowMessage )]
		public void OnOpenCommandWindow( BattleTypeConstants.CommandSelectType type )
		{
			this.inputArrowStateMachine.Change( (int)type );
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
		/// 味方コマンドの決定処理.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public void DecideAllyCommand( int id )
		{
			this.BroadcastMessage( refAllyCommandEventHolder, BattleMessageConstants.DecideCommandMessage, id );
		}
		
		/// <summary>
		/// 特殊能力コマンドの決定処理.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public void DecideAbilityCommand( int id )
		{
			this.BroadcastMessage( refAbilityCommandEventHolder, BattleMessageConstants.DecideCommandMessage, id );
		}

		/// <summary>
		/// コマンド選択完了処理.
		/// </summary>
		public void Complete()
		{
			this.CurrentCommandSelectAlly.DecideCommand( CommandData );
			var tempAllyData = this.CurrentCommandSelectAlly;
			this.CurrentCommandSelectAlly = null;
			this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.CompleteCommandSelectMessage, tempAllyData );
			Debug.Log( "?" );
		}

		public void Cancel()
		{
//			ChangeInputState( BattleTypeConstants.CommandSelectType.Main );
		}

		private IEnumerator LockInputCoroutine()
		{
			this.canInput = false;

			yield return new WaitForEndOfFrame();

			this.canInput = true;
		}

		/// <summary>
		/// 入力可能か返す.
		/// </summary>
		/// <value><c>true</c> if this instance is possible input; otherwise, <c>false</c>.</value>
		private bool IsPossibleInput
		{
			get
			{
				return this.canInput && this.CurrentCommandSelectAlly != null;
			}
		}
	}
}
