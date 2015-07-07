using UnityEngine;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベントをキャッチして情報テキストを設定するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetInformation : MyMonoBehaviour, I_OnExecuteCommandHookable
	{
		[SerializeField]
		private Conditioner refConditioner;

		[SerializeField]
		private InformationTextData refData;

		[SerializeField]
		private TypeConstants.SetTextInformationType type;

		[Attribute.MessageMethodReceiver( MessageConstants.ExecuteCommandMessage )]
		public void OnExecuteCommand( Battle.MessageConstants.ExecuteCommandHook hook )
		{
			if( !this.IsCondition )
			{
				return;
			}

			var methodName = this.type == TypeConstants.SetTextInformationType.Set
				? MessageConstants.SetInformationTextMessage
					: this.type == TypeConstants.SetTextInformationType.Append
				? MessageConstants.AppendInformationTextMessage
				: MessageConstants.NewLineInformationTextMessage;

			this.BroadcastMessage( SceneRootBase.Root, methodName, InformationTextBuilder.Build( this.refData ) );
		}

		private bool IsCondition
		{
			get
			{
				if( this.refConditioner == null )
				{
					return true;
				}

				return this.refConditioner.Condition;
			}
		}
	}
}
