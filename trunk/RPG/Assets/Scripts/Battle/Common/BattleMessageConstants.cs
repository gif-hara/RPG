/*===========================================================================*/
/*
*     * FileName    : BattleMessageConstants.cs
*
*     * Description : .
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
	/// .
	/// </summary>
	public class BattleMessageConstants
	{
		/// <summary>
		/// バトルシステム初期化時のメッセージ.
		/// </summary>
		public const string PreInitializeSystemMessage = "OnPreInitializeSystem";

		/// <summary>
		/// バトル開始時のメッセージ.
		/// </summary>
		public const string StartBattleMessage = "OnStartBattle";

		/// <summary>
		/// コマンド選択開始時のメッセージ.
		/// </summary>
		public const string StartCommandSelectMessage = "OnStartCommandSelect";

		/// <summary>
		/// コマンドを選択するキャラクターを選択した際のメッセージ.
		/// </summary>
		[Attribute.MessageMethodArgument( typeof( BattleAllyPartyManager.AllyData ) )]
		public const string SelectCommandSelectCharacterMessage = "OnSelectCommandSelectCharacter";

		/// <summary>
		/// コマンドが決定した際のメッセージ.
		/// </summary>
		[Attribute.MessageMethodArgument( typeof( BattleAllyPartyManager.AllyData ) )]
		public const string DecisionCommandMessage = "OnDecisionCommand";

		/// <summary>
		/// アクティブタイム更新処理開始時のメッセージ.
		/// </summary>
		public const string StartUpdateActiveTimeMessage = "OnStartUpdateActiveTime";

		/// <summary>
		/// いずれかの味方のアクティブタイムが最大値に達した際のメッセージ.
		/// </summary>
		public const string EndUpdateActiveTimeMessage = "OnEndUpdateActiveTime";

		/// <summary>
		/// コマンドを実行する際のメッセージ.
		/// </summary>
		public const string StartCommandExecuteMessage = "OnStartCommandExecute";

		/// <summary>
		/// コマンド実行終了時のメッセージ.
		/// </summary>
		public const string EndCommandExecuteMessage = "OnEndCommandExecute";
	}

	public class BattleTypeConstants
	{
		/// <summary>
		/// コマンドタイプ.
		/// </summary>
		public enum CommandType : int
		{
			/// <summary>
			/// 無し.
			/// </summary>
			None,

			/// <summary>
			/// 戦う.
			/// </summary>
			UsualAttack,
		}
	}
}
