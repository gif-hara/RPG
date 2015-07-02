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

		public CommandInputElementBase( TypeConstants.CommandSelectType type )
			:base( (int)type )
		{
		}

		public override void Enter (BattleAllyCommandSelector owner)
		{
			commandId = 0;
		}

		/// <summary>
		/// 決定処理.
		/// </summary>
		public abstract void DecisionAction(BattleAllyCommandSelector owner);

		/// <summary>
		/// キャンセル処理.
		/// </summary>
		public abstract void CancelAction(BattleAllyCommandSelector owner);

		/// <summary>
		/// 左キー処理.
		/// </summary>
		public abstract void LeftAction(BattleAllyCommandSelector owner);

		/// <summary>
		/// 右キー処理.
		/// </summary>
		public abstract void RightAction(BattleAllyCommandSelector owner);

		/// <summary>
		/// 上キー処理.
		/// </summary>
		public abstract void UpAction(BattleAllyCommandSelector owner);

		/// <summary>
		/// 下キー処理.
		/// </summary>
		public abstract void DownAction(BattleAllyCommandSelector owner);
	}
}
