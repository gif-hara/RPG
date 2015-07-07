using UnityEngine;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時にテストで文字列を表示するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetTestString : MyMonoBehaviour, I_OnExecuteCommandHookable
	{
		[SerializeField]
		private string message;

		[SerializeField]
		private TypeConstants.SetTextInformationType type;
		
		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand( Battle.MessageConstants.ExecuteCommandHook hook )
		{
			Development.TODO( message + " はテストなので問題無くなったら削除する." );
			var methodName = this.type == TypeConstants.SetTextInformationType.Set
				? MessageConstants.SetInformationTextMessage
					: this.type == TypeConstants.SetTextInformationType.Append
					? MessageConstants.AppendInformationTextMessage
					: MessageConstants.NewLineInformationTextMessage;
			
			this.BroadcastMessage( SceneRootBase.Root, methodName, message );
		}
	}
}
