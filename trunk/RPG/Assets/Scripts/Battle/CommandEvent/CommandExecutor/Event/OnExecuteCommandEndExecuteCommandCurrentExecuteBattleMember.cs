using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行時にコマンド実行者の終了処理を行うコンポーネント.
	/// </summary>
	public class OnExecuteCommandEndExecuteCommandCurrentExecuteBattleMember : MyMonoBehaviour, I_OnExecuteCommandHookable
	{
		[Attribute.MessageMethodReceiver( Battle.MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand (Battle.MessageConstants.ExecuteCommandHook hook)
		{
			AllPartyManager.Instance.ActiveTimeMaxBattleCharacter.EndExecuteCommand();
		}
	}
}
