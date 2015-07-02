using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に次のイベントを設定するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetNextEventPrefab : MyMonoBehaviour
	{
		[SerializeField]
		private GameObject prefabEventHolder;
		
		[Attribute.MessageMethodReceiver( BattleMessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand( BattleMessageConstants.ExecuteCommandHook hook )
		{
			var instance = Instantiate( prefabEventHolder );
			SendMessage( gameObject, BattleMessageConstants.InstantiateCustomizeMessage, instance );
			hook.Executer.InsertEventHolder( instance );
		}
	}
}
