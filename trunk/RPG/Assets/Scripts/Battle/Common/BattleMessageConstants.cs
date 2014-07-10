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
