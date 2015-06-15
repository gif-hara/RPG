/*===========================================================================*/
/*
*     * FileName    : OnExecuteCommandSetInformation.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
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
		public enum SetTextType : int
		{
			Set,
			Append,
			NewLine,
		}

		[SerializeField]
		private InformationLabelSetterCommandEvent refData;

		[SerializeField]
		private SetTextType type;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand()
		{
			var methodName = this.type == SetTextType.Set
				? BattleMessageConstants.SetInformationTextMessage
				: this.type == SetTextType.Append
				? BattleMessageConstants.AppendInformationTextMessage
				: BattleMessageConstants.NewLineInformationTextMessage;

			this.BroadcastMessage( SceneRootBase.Root, methodName, Message );
		}

		private string Message
		{
			get
			{
				return StringAsset.Format( this.refData.Key, this.FormatArguments );
			}
		}

		private object[] FormatArguments
		{
			get
			{
				List<object> result = new List<object>();
				for( int i=0,imax=refData.Parameter.Count; i<imax; i++ )
				{
					switch( refData.Parameter[i] )
					{
					case CommandEventConstants.InformationParameterType.ExecuteMemberName:
						result.Add( AllPartyManager.Instance.ActiveTimeMaxBattleMember.Data.name );
						break;
					}
				}
				return result.ToArray();
			}
		}
	}
}
