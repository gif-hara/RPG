using UnityEngine;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベント時に条件付きで次のイベントを設定するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetNextEventCondition : MonoBehaviour
	{
		[SerializeField]
		private Common.Conditioner refConditioner;

		[SerializeField]
		private GameObject refPositiveEventHolder;

		[SerializeField]
		private GameObject refNegativeEventHolder;
		
		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand( MessageConstants.ExecuteCommandHook hook )
		{
			if( this.refConditioner.Condition )
			{
				hook.Executer.InsertEventHolder( this.refPositiveEventHolder );
			}
			else
			{
				hook.Executer.InsertEventHolder( this.refNegativeEventHolder );
			}
		}
	}
}
