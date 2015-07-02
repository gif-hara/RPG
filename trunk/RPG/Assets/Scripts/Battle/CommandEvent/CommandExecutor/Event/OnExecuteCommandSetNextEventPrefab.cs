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
		
		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand( MessageConstants.ExecuteCommandHook hook )
		{
			var instance = Instantiate( prefabEventHolder );
			SendMessage( gameObject, MessageConstants.InstantiateCustomizeMessage, instance );
			hook.Executer.InsertEventHolder( instance );
		}
	}
}
