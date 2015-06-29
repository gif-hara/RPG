using UnityEngine;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時にテストで文字列を表示するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetTestString : MyMonoBehaviour
	{
		[SerializeField]
		private string message;

		[SerializeField]
		private BattleTypeConstants.SetTextInformationType type;
		
		[Attribute.MessageMethodReceiver( BattleMessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand()
		{
			Development.TODO( message + " はテストなので問題無くなったら削除する." );
			var methodName = this.type == BattleTypeConstants.SetTextInformationType.Set
				? BattleMessageConstants.SetInformationTextMessage
					: this.type == BattleTypeConstants.SetTextInformationType.Append
					? BattleMessageConstants.AppendInformationTextMessage
					: BattleMessageConstants.NewLineInformationTextMessage;
			
			this.BroadcastMessage( SceneRootBase.Root, methodName, message );
		}
	}
}
