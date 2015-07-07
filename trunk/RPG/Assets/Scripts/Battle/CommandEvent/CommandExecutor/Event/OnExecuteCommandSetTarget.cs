using UnityEngine;
using System.Collections.Generic;
using RPG;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時にターゲットを選択するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetTarget : MyMonoBehaviour, I_OnExecuteCommandHookable
	{
		[Attribute.MessageMethodReceiver( Battle.MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand (Battle.MessageConstants.ExecuteCommandHook hook)
		{
			var selectCommandData = AllPartyManager.Instance.ActiveTimeMaxBattleCharacter.SelectCommandData;
			selectCommandData.SetTarget( selectCommandData.GetTargetBattleCharacter() );
		}
	}
}
