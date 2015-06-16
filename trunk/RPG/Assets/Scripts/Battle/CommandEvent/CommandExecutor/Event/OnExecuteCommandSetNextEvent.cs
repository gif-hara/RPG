/*===========================================================================*/
/*
*     * FileName    : OnExecuteCommandSetNextEvent.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に次のイベントを設定するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetNextEvent : MyMonoBehaviour
	{
		[SerializeField]
		private CommandExecutor refExecutor;

		[SerializeField]
		private GameObject refEventHolder;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand()
		{
			this.refExecutor.SetEventHolder( this.refEventHolder );
		}
	}
}
