using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に次のイベントを設定するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetNextEvent : MonoBehaviour, I_OnExecuteCommandHookable
	{
		[SerializeField]
		private GameObject refEventHolder;

		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand( MessageConstants.ExecuteCommandHook hook )
		{
			hook.Executer.InsertEventHolder( this.refEventHolder );
		}

		public void SetEventHolder( GameObject obj )
		{
			this.refEventHolder = obj;
		}
	}
}
