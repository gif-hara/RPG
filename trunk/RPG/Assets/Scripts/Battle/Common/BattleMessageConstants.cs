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
		/// コマンドが決定した際のメッセージ.
		/// </summary>
		[Attribute.MessageMethodArgument( typeof( AllyData ) )]
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

		/// <summary>
		/// コマンドIDが変更された際のメッセージ.
		/// </summary>
		[Attribute.MessageMethodArgument( typeof( int ) )]
		public const string ModifiedCommandIdMessage = "OnModifiedCommandId";

		public class OpenCommandWindowData
		{
			public BattleTypeConstants.CommandSelectType SelectType{ private set; get; }

			public AllyData AllyData{ private set; get; }

			public OpenCommandWindowData( BattleTypeConstants.CommandSelectType selectType, AllyData allyData )
			{
				this.SelectType = selectType;
				this.AllyData = allyData;
			}

			public override string ToString ()
			{
				return string.Format ("[OpenCommandWindowData: SelectType={0}, AllyData={1}]", SelectType, AllyData);
			}
		}
		[Attribute.MessageMethodArgument( typeof( OpenCommandWindowData ) )]
		public const string OpenCommandWindowMessage = "OnOpenCommandWindow";
	}

	public class BattleTypeConstants
	{
		/// <summary>
		/// コマンドタイプ.
		/// </summary>
		public enum CommandType : int
		{
			/// <summary> 無し. </summary>
			None,

			/// <summary> 特殊能力. </summary>
			Ability,

			/// <summary> 戦う. </summary>
			Attack,

			/// <summary> 道具. </summary>
			Item,

			/// <summary> 守る. </summary>
			Deffence,

			/// <summary> かばう. </summary>
			CoverUp,

			/// <summary> 逃げる. </summary>
			Escape,

		}

		/// <summary>
		/// コマンド選択タイプ.
		/// </summary>
		public enum CommandSelectType : int
		{
			/// <summary> メインコマンド. </summary>
			Main,

			/// <summary> 特殊能力. </summary>
			Ability,

			/// <summary> アイテム. </summary>
			Item,

			/// <summary> 味方. </summary>
			Ally,

			/// <summary> 敵. </summary>
			Enemy,
		}

		/// <summary>
		/// 特殊能力タイプ.
		/// </summary>
		public enum AbilityType : int
		{
			/// <summary> 無し. </summary>
			None,

			/// <summary> 術. </summary>
			Magic,

			/// <summary> すもう技. </summary>
			Sumo,

			/// <summary> 盗む. </summary>
			Steal,
		}
	}
}
