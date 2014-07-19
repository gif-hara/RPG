/*===========================================================================*/
/*
*     * FileName    : CommandData.cs
*
*     * Description : コマンドデータ.
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
	/// コマンドデータ.
	/// </summary>
	public abstract class CommandData : FactoryElement
	{
		/// <summary>
		/// コマンドの状態定義.
		/// </summary>
		public enum State : int
		{
			None,
			/// <summary> 予告. </summary>
			Notice,
			/// <summary> 実行. </summary>
			Execute,
			/// <summary> 結果. </summary>
			Result,
			/// <summary> 終了. </summary>
			End,
		}
		/// <summary>
		/// 誰に対してコマンドを実行するかのリスト.
		/// </summary>
		/// <value>The target identifier list.</value>
		public List<int> TargetIdList{ private set; get; }

		/// <summary>
		/// 現在の状態.
		/// </summary>
		private State currentState = State.None;

		public CommandData( BattleTypeConstants.CommandType type )
			:base( (int)type )
		{
			this.TargetIdList = new List<int>();
		}

		/// <summary>
		/// ターゲットIDの追加.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public void AddTargetId( int id )
		{
			this.TargetIdList.Add( id );
		}

		public Queue<List<CommandEventBase>> NextState( BattleMemberData executeMember, CommandEventHolder eventHolder )
		{
			this.currentState = (State)( (int)this.currentState + 1 );
			return StateFunction( executeMember, eventHolder );
		}

		/// <summary>
		/// 内部初期化処理.
		/// </summary>
		protected void InternalInitialize()
		{
			this.TargetIdList.Clear();
			this.currentState = State.None;
		}

		private System.Func<BattleMemberData, CommandEventHolder, Queue<List<CommandEventBase>>> StateFunction
		{
			get
			{
				System.Func<BattleMemberData, CommandEventHolder, Queue<List<CommandEventBase>>>[] f =
					new System.Func<BattleMemberData, CommandEventHolder, Queue<List<CommandEventBase>>>[]
				{
					Notice,
					Execute,
					Result,
					End,
				};

				return f[(int)this.currentState - 1];
			}
		}

		/// <summary>
		/// 予告処理.
		/// </summary>
		/// <param name="executeMember">Execute member.</param>
		/// <param name="eventHolder">Event holder.</param>
		protected abstract Queue<List<CommandEventBase>> Notice( BattleMemberData executeMember, CommandEventHolder eventHolder );

		/// <summary>
		/// 実行処理.
		/// </summary>
		/// <param name="executeMember">Execute member.</param>
		/// <param name="eventHolder">Event holder.</param>
		protected abstract Queue<List<CommandEventBase>> Execute( BattleMemberData executeMember, CommandEventHolder eventHolder );

		/// <summary>
		/// 結果処理.
		/// </summary>
		/// <param name="executeMember">Execute member.</param>
		/// <param name="eventHolder">Event holder.</param>
		protected abstract Queue<List<CommandEventBase>> Result( BattleMemberData executeMember, CommandEventHolder eventHolder );

		/// <summary>
		/// 終了処理.
		/// </summary>
		/// <param name="executeMember">Execute member.</param>
		/// <param name="eventHolder">Event holder.</param>
		protected abstract Queue<List<CommandEventBase>> End( BattleMemberData executeMember, CommandEventHolder eventHolder );

		public override string ToString ()
		{
			return string.Format ("[CommandData: TargetIdList={0}]", TargetIdList);
		}
	}
}
