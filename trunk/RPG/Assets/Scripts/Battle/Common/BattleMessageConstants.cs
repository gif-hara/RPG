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
		public const string CompleteCommandSelectMessage = "OnCompleteCommandSelect";

		/// <summary>
		/// アクティブタイム更新処理開始時のメッセージ.
		/// </summary>
		public const string StartUpdateActiveTimeMessage = "OnStartUpdateActiveTime";

		/// <summary>
		/// いずれかのキャラクターのアクティブタイムが最大値に達した際のメッセージ.
		/// </summary>
		public const string EndUpdateActiveTimeMessage = "OnEndUpdateActiveTime";

		/// <summary>
		/// コマンドが実行された際のメッセージ.
		/// </summary>
		public const string ExecuteCommandMessage = "OnExecuteCommand";

		/// <summary>
		/// コマンド実行終了時のメッセージ.
		/// </summary>
		public const string EndCommandExecuteMessage = "OnEndCommandExecute";

		/// <summary>
		/// コマンドIDが変更された際のメッセージ.
		/// </summary>
		[Attribute.MessageMethodArgument( typeof( int ) )]
		public const string ModifiedCommandIdMessage = "OnModifiedCommandId";

		/// <summary>
		/// ステートがアクティブ状態になった際のメッセージ.
		/// </summary>
		public const string ActiveStateMessage = "OnActiveState";

		/// <summary>
		/// ステートが非アクティブ状態になった際のメッセージ.
		/// </summary>
		public const string DeactiveStateMessage = "OnDeactiveState";

		/// <summary>
		/// コマンドが選択された際のメッセージ.
		/// </summary>
		[Attribute.MessageMethodArgument( typeof( int ) )]
		public const string DecideCommandMessage = "OnDecideCommand";

		/// <summary>
		/// コマンドウィンドウを表示する際のメッセージ.
		/// </summary>
		public const string OpenCommandWindowMessage = "OnOpenCommandWindow";

		/// <summary>
		/// 情報ラベルに文字列を設定するメッセージ.
		/// </summary>
		[Attribute.MessageMethodArgument( typeof( string ) )]
		public const string SetInformationTextMessage = "OnSetInformationText";

		/// <summary>
		/// 情報ラベルに文字列を追加するメッセージ.
		/// </summary>
		[Attribute.MessageMethodArgument( typeof( string ) )]
		public const string AppendInformationTextMessage = "OnAppendInformationText";

		/// <summary>
		/// 情報ラベルに文字列を新しい行に追加するメッセージ.
		/// </summary>
		[Attribute.MessageMethodArgument( typeof( string ) )]
		public const string NewLineInformationTextMessage = "OnNewLineInformationText";
	}
}
