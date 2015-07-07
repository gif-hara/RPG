using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に特殊能力データのGroupTypeからプレハブを生成して次のイベントを設定するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetNextEventFromAbilityDataOfGroupType : MyMonoBehaviour, I_OnExecuteCommandHookable
	{
		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand( MessageConstants.ExecuteCommandHook hook )
		{
			var selectCommandData = AllPartyManager.Instance.ActiveTimeMaxBattleCharacter.SelectCommandData;
			var instance = Instantiate( selectCommandData.AbilityData.PrefabGroupType );
			SendMessage( gameObject, MessageConstants.InstantiateCustomizeMessage, instance );
			hook.Executer.InsertEventHolder( instance );
		}
	}
}
