using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に特殊能力データのコマンドイベントプレハブを生成して次のイベントを設定するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetNextEventFromAbilityData : MyMonoBehaviour
	{
		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand( MessageConstants.ExecuteCommandHook hook )
		{
			var selectCommandData = AllPartyManager.Instance.ActiveTimeMaxBattleCharacter.SelectCommandData;
			var instance = Instantiate( selectCommandData.AbilityData.PrefabCommandEventHolder );
			SendMessage( gameObject, MessageConstants.InstantiateCustomizeMessage, instance );
			hook.Executer.InsertEventHolder( instance );
		}
	}
}
