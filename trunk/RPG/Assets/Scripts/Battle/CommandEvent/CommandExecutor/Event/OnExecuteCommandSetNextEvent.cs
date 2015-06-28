using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に条件付きで次のイベントを設定するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetNextEvent : MonoBehaviour
	{
		[SerializeField]
		private GameObject refEventHolder;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand( BattleMessageConstants.ExecuteCommandHook hook )
		{
			hook.Executer.InsertEventHolder( this.refEventHolder );
		}
	}
}
