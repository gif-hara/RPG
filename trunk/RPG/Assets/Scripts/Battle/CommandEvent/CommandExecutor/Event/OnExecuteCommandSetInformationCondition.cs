using UnityEngine;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベントをキャッチして情報テキストを設定するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetInformationCondition : MyMonoBehaviour, I_OnExecuteCommandHookable
	{
		[SerializeField]
		private Conditioner refConditioner;

		[SerializeField]
		private InformationTextData refPositiveData;
		
		[SerializeField]
		private InformationTextData refNegativeData;
		
		[SerializeField]
		private TypeConstants.SetTextInformationType type;

		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand( Battle.MessageConstants.ExecuteCommandHook hook )
		{
			var methodName = this.type == TypeConstants.SetTextInformationType.Set
				? MessageConstants.SetInformationTextMessage
					: this.type == TypeConstants.SetTextInformationType.Append
				? MessageConstants.AppendInformationTextMessage
				: MessageConstants.NewLineInformationTextMessage;

			var data = this.refConditioner.Condition
				? this.refPositiveData
				: this.refNegativeData;
			this.BroadcastMessage( SceneRootBase.Root, methodName, InformationTextBuilder.Build( data ) );
		}
	}
}
