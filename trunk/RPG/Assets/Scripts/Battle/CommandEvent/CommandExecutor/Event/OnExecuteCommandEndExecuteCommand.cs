/*===========================================================================*/
/*
*     * FileName    : OnExecuteCommandEndExecuteCommand.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時にコマンド実行終了イベントを送信するコンポーネント.
	/// </summary>
	public class OnExecuteCommandEndExecuteCommand : MyMonoBehaviour
	{
		[SerializeField]
		private CommandExecutor refParent;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand()
		{
			Destroy( this.refParent.gameObject );
			AllPartyManager.Instance.ActiveTimeMaxBattleMember.EndExecuteCommand();
			this.BroadcastMessage( SceneRootBase.Root, BattleMessageConstants.EndCommandExecuteMessage );
		}
	}
}
