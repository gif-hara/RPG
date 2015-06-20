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
		[SerializeField]
		private InformationLabelSetterCommandEvent refData;

		[SerializeField]
		private BattleTypeConstants.SetTextInformationType type;

		[Attribute.MessageMethodReceiver( BattleMessageConstants.ExecuteCommandMessage )]
		void OnExecuteCommand()
		{
			var methodName = this.type == BattleTypeConstants.SetTextInformationType.Set
				? BattleMessageConstants.SetInformationTextMessage
					: this.type == BattleTypeConstants.SetTextInformationType.Append
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
					case BattleTypeConstants.InformationParameterType.ExecuteMemberName:
						result.Add( AllPartyManager.Instance.ActiveTimeMaxBattleMember.CharacterData.name );
						break;
					case BattleTypeConstants.InformationParameterType.GiveDamage:
						result.Add( AllPartyManager.Instance.ActiveTimeMaxBattleMember.SelectCommandData.GiveDamage.Damage );
						break;
					case BattleTypeConstants.InformationParameterType.TargetName:
						result.Add( AllPartyManager.Instance.ActiveTimeMaxBattleMember.SelectCommandData.GiveDamage.Target.CharacterData.name );
						break;
					}
				}
				return result.ToArray();
			}
		}
	}
}
