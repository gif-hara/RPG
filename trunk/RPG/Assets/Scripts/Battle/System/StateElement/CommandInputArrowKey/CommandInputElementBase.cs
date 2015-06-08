/*===========================================================================*/
/*
*     * FileName    : CommandInputElementBase.cs
*
*     * Description : コマンドのキー操作抽象クラス.
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
	/// コマンドのキー操作抽象クラス.
	/// </summary>
	public abstract class CommandInputElementBase : StateElementBase<BattleAllyCommandSelector>
	{
		protected static int commandId = 0;

		public CommandInputElementBase( BattleTypeConstants.CommandSelectType type )
			:base( (int)type )
		{
		}

		public override void Enter (BattleAllyCommandSelector owner)
		{
			commandId = 0;
		}
		public override void Update (BattleAllyCommandSelector owner)
		{
			if( MyInput.Decision )
			{
				DecisionAction( owner );
			}
			if( MyInput.Cancel )
			{
				CancelAction( owner );
			}
			if( MyInput.Left )
			{
				LeftAction( owner );
			}
			if( MyInput.Right )
			{
				RightAction( owner );
			}
			if( MyInput.Up )
			{
				UpAction( owner );
			}
			if( MyInput.Down )
			{
				DownAction( owner );
			}
		}

		public override void Exit (BattleAllyCommandSelector owner)
		{
		}

		/// <summary>
		/// 決定処理.
		/// </summary>
		protected abstract void DecisionAction(BattleAllyCommandSelector owner);

		/// <summary>
		/// キャンセル処理.
		/// </summary>
		protected abstract void CancelAction(BattleAllyCommandSelector owner);

		/// <summary>
		/// 左キー処理.
		/// </summary>
		protected abstract void LeftAction(BattleAllyCommandSelector owner);

		/// <summary>
		/// 右キー処理.
		/// </summary>
		protected abstract void RightAction(BattleAllyCommandSelector owner);

		/// <summary>
		/// 上キー処理.
		/// </summary>
		protected abstract void UpAction(BattleAllyCommandSelector owner);

		/// <summary>
		/// 下キー処理.
		/// </summary>
		protected abstract void DownAction(BattleAllyCommandSelector owner);
	}
}
