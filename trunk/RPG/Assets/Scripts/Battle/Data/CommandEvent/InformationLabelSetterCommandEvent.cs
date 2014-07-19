/*===========================================================================*/
/*
*     * FileName    : InformationLabelSetterCommandEvent.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Battle
{
	/// <summary>
	/// 情報ウィンドウのラベルを設定するコマンドイベント.
	/// </summary>
	public class InformationLabelSetterCommandEvent : CommandEventBase
	{
		[SerializeField]
		private string informationKey;

		[SerializeField]
		private List<CommandEventConstants.InformationParameterType> param;

		public string Message( AllParty allParty, BattleMemberData executeMember, CommandData commandData )
		{
			return StringAsset.Format( informationKey, FormatArguments( allParty, executeMember, commandData ) );
		}

		private object[] FormatArguments( AllParty allParty, BattleMemberData executeMember, CommandData commandData )
		{
			List<object> result = new List<object>();
			for( int i=0,imax=param.Count; i<imax; i++ )
			{
				switch( param[i] )
				{
				case CommandEventConstants.InformationParameterType.ExecuteMemberName:
					result.Add( executeMember.Data.name );
					break;
				}
			}
			return result.ToArray();
		}

		public override CommandEventConstants.EventType EventType
		{
			get
			{
				return CommandEventConstants.EventType.Information;
			}
		}
	}
}
