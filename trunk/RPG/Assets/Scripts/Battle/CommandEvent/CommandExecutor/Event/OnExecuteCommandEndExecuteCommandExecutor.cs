using UnityEngine;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時にコマンド実行クラスの終了処理を行うコンポーネント.
	/// </summary>
	public class OnExecuteCommandEndExecuteCommandExecutor : MyMonoBehaviour, I_OnExecuteCommandHookable
	{
		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand( MessageConstants.ExecuteCommandHook hook )
		{
			hook.Executer.End();
		}
	}
}
