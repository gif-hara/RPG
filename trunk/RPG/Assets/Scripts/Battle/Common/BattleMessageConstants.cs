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

		/// <summary>
		/// コマンドウィンドウを表示する際のメッセージ.
		/// </summary>
		[Attribute.MessageMethodArgument( typeof( OpenCommandWindowData ) )]
		public const string OpenCommandWindowMessage = "OnOpenCommandWindow";

		public class NoticeCommandEventArgument
		{
			public List<CommandEventBase> CommandEventList{ private set; get; }

			public AllParty AllParty{ private set; get; }

			public BattleMemberData ExecuteMember{ private set; get; }

			public CommandData CommandData{ private set; get; }

			public NoticeCommandEventArgument( List<CommandEventBase> commandEventList, AllParty allParty, BattleMemberData executeMember, CommandData commandData )
			{
				this.CommandEventList = commandEventList;
				this.AllParty = allParty;
				this.ExecuteMember = executeMember;
				this.CommandData = commandData;
			}
		}
		/// <summary>
		/// コマンドイベントを通知するメッセージ.
		/// </summary>
		[Attribute.MessageMethodArgument( typeof( NoticeCommandEventArgument ) )] 
		public const string NoticeCommandEventMessage = "OnNoticeCommandEvent";

		/// <summary>
		/// コマンドが実行された際のメッセージ.
		/// </summary>
		public const string ExecuteCommandMessage = "OnExecuteCommand";

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

	public class BattleTypeConstants
	{
		/// <summary>
		/// コマンドタイプ.
		/// </summary>
		public enum CommandType : int
		{
			/// <summary> 戦う. </summary>
			Attack,

			/// <summary> 道具. </summary>
			Item,

			/// <summary> 守る. </summary>
			Defence,

			/// <summary> かばう. </summary>
			CoverUp,

			/// <summary> 逃げる. </summary>
			Escape,

			/// <summary> 無し. </summary>
			None,
			
			/// <summary> 術. </summary>
			Magic,

			/// <summary> すもう技. </summary>
			Sumo,
			
			/// <summary> 盗む. </summary>
			Steal,
		}

		/// <summary>
		/// コマンド選択タイプ.
		/// </summary>
		public enum CommandSelectType : int
		{
			/// <summary> メインコマンド. </summary>
			Main,

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
