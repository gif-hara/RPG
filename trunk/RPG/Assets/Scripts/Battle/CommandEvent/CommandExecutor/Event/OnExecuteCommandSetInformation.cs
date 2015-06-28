using UnityEngine;
using System.Collections.Generic;
using RPG.Common;

namespace RPG.Battle
{
	/// <summary>
	/// コマンド実行イベントをキャッチして情報テキストを設定するコンポーネント.
	/// </summary>
	public class OnExecuteCommandSetInformation : MyMonoBehaviour
	{
		[SerializeField]
		private Conditioner refConditioner;

		[SerializeField]
		private InformationTextData refData;

		[SerializeField]
		private BattleTypeConstants.SetTextInformationType type;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand()
		{
			if( !this.IsCondition )
			{
				return;
			}

			var methodName = this.type == BattleTypeConstants.SetTextInformationType.Set
				? BattleMessageConstants.SetInformationTextMessage
					: this.type == BattleTypeConstants.SetTextInformationType.Append
				? BattleMessageConstants.AppendInformationTextMessage
				: BattleMessageConstants.NewLineInformationTextMessage;

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
